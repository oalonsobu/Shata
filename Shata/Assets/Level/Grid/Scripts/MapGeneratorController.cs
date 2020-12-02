using System.Collections.Generic;
using System.Linq;
using Level.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Variables;

namespace Level.Grid
{
    public enum HexDirection {
        NE, E, SE, SW, W, NW
    }

    public enum MapSize {
        Small = 30, Medium = 50, Large = 70
    }
    
    public enum CellType {
        //Identifiers by elevation
        DeepWater = -1, Water = 0, Grass = 1, LowMountain = 2, Mountain = 3, HighMountain = 4, 
        //Special identifiers
        Fertile = 10, Forest = 11, Stone = 12, FishArea = 13
    }
    
    public class MapGeneratorController : MonoBehaviour
    {
        //TODO: I think that maybe we can store a custom object, maybe something less consuming
        CellBase[] grid;
        CustomCellLinkedList<int> pendingToVisit = new CustomCellLinkedList<int>();
        CellType[] cellTypes;

        [SerializeField]                  private int seed;
        [SerializeField]                  private MapSize mapSize = MapSize.Small;
        [SerializeField] [Range(10,40)]   private float jitter;
        [SerializeField] [Range(100,150)] private int minLandSize;
        [SerializeField] [Range(150,200)] private int maxLandSize;
        [SerializeField] [Range(5,95)]    private int landPercentage;
        [SerializeField] [Range(5,10)]    private int mapBorderX;
        [SerializeField] [Range(5,10)]    private int mapBorderY;
        [SerializeField] [Range(0,2)]     private int mountainReduction;
        [SerializeField] [Range(5,10)]    private int fertileLandPopulation;
        [SerializeField] [Range(5,10)]    private int quarryPopulation;
        [SerializeField] [Range(5,10)]    private int forestLevelPopulation;

        const float hexRadius = 0.866025404f;
        private const float maxElevation = 6;
        
        void Awake()
        {
            initSeed();
            createEmptyMap((int) mapSize, (int) mapSize);
            createWorld();
            instantiateCells();
        }

        void initSeed()
        {
            if (seed == 0)
            {
                //it's a little strange to set the random seed with a random :P
                seed = Random.Range(0, int.MaxValue);
            }
            
            Random.InitState(seed);
        }

        void createEmptyMap(int width, int height)
        {
            grid = new CellBase[height * width];
            cellTypes = new CellType[height * width];
            
            for (int z = 0, i = 0; z < height; z++) {
                for (int x = 0; x < width; x++)
                {
                    cellTypes[i] = 0;
                    createWaterCell(x, z, i);
                    setNeigbours(width, x, z, i);
                    i++;
                }
            }
        }

        void setNeigbours(int width, int currentWidth, int currentHeight, int i)
        {
            if (currentWidth > 0)
            {
                grid[i].addNeigbour(grid[i - 1], HexDirection.W);
                grid[i - 1].addNeigbour(grid[i], HexDirection.E);
            }
                    
            if (currentHeight > 0) {
                if ((currentHeight & 1) == 0) {
                    grid[i].addNeigbour(grid[i - width], HexDirection.SE);
                    grid[i - width].addNeigbour(grid[i], HexDirection.NW);
                    if (currentWidth > 0) {
                        grid[i].addNeigbour(grid[i - width - 1], HexDirection.SW);
                        grid[i - width - 1].addNeigbour(grid[i], HexDirection.NE);
                    }
                }
                else {
                    grid[i].addNeigbour(grid[i - width], HexDirection.SW);
                    grid[i - width].addNeigbour(grid[i], HexDirection.NE);
                    if (currentWidth < width - 1) {
                        grid[i].addNeigbour(grid[i - width + 1], HexDirection.SE);
                        grid[i - width + 1].addNeigbour(grid[i], HexDirection.NW);
                    }
                }
            }
        }

       
        
        void createWaterCell (int x, int z, int id) 
        {
            Vector3 p;
            int evenRow = z % 2; //1 or 0
            p.x = x + 0.5f * evenRow;
            p.y = 0f;
            p.z = z * hexRadius;

            grid[id] = new CellBase(id, p);
            cellTypes[id] = CellType.Water;
        }

        void instantiateCells()
        {
            GameObject aux;
            for (int i = 0; i < grid.Length; i++)
            {
                switch (cellTypes[grid[i].Id])
                {
                    case CellType n when n == CellType.DeepWater:
                        grid[i].CellType = new DeepWater();
                        break;
                    case CellType n when n == CellType.Water:
                        grid[i].CellType = new Water();
                        break;
                    case CellType n when n >= CellType.Grass && n <= CellType.Grass + mountainReduction:
                        grid[i].CellType = new Grass();
                        break;
                    case CellType n when n == CellType.LowMountain + mountainReduction:
                        grid[i].CellType = new LowMountain();
                        break;
                    case CellType n when n == CellType.Mountain + mountainReduction:
                        grid[i].CellType = new Mountain();
                        break;
                    case CellType n when n == CellType.HighMountain + mountainReduction:
                        grid[i].CellType = new HighMountain();
                        break;
                    case CellType n when n == CellType.Fertile:
                        grid[i].CellType = new Fertile();
                        break;
                    case CellType n when n == CellType.Forest:
                        grid[i].CellType = new Forest();
                        break;
                    case CellType n when n == CellType.Stone:
                        grid[i].CellType = new Stone();
                        break;
                    case CellType n when n == CellType.FishArea:
                        //TODO: create fishArea cell
                        grid[i].CellType = new Water();
                        break;
                    default:
                        grid[i].CellType = new Fertile();
                        break;
                }
                aux = Instantiate<GameObject>(grid[i].CellType.getBasePrefab(), transform, false);
                aux.GetComponent<CellController>().CellBase = grid[i];
                aux.transform.localPosition = grid[i].Position;
            }
        }

        int getRandomCell()
        {
            int x, maxX, minX, y, maxY, minY;
            minX = mapBorderX;
            minY = mapBorderY;
            maxX = (int) mapSize - mapBorderX;
            maxY = (int) mapSize - mapBorderY;
            x = Random.Range(minX, maxX);
            y = Random.Range(minY, maxY);
            return grid[(int) mapSize * x + y].Id;
        }
        
        int getGrassRandomCell()
        {
            List<int> nonVisitedCellIndexes = new List<int>();
            for (int id = 0; id < cellTypes.Length; id++)
            {
                if (cellTypes[id] == CellType.Grass)
                {
                    nonVisitedCellIndexes.Add(id);
                }                
            }
            
            return nonVisitedCellIndexes[Random.Range(0, nonVisitedCellIndexes.Count)];
        }

        void createWorld()
        {
            int landBudget = Mathf.RoundToInt(grid.Length * landPercentage * 0.01f);
            while (landBudget > 0)
            {
                upriseTerrain(Random.Range(minLandSize, maxLandSize),ref landBudget);
            }

            createDeepWater();
            createFertileLand();
            createQuarry();
            createForest();
        }

        void upriseTerrain(int size, ref int landBudget)
        {
            int currentSize = 0;
            List<int> alreadyVisited = new List<int>();
            int cell = getRandomCell();
            pendingToVisit.queue(cell, 1);
            
            while (pendingToVisit.Count > 0 && landBudget != 0 && currentSize < size)
            {
                int current = pendingToVisit.dequeue();
                alreadyVisited.Add(current);
                currentSize += 1;
                if ((int) cellTypes[current] < maxElevation)
                {
                    cellTypes[current]++;
                }

                for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++) {
                    CellBase neighbor = grid[current].getNeigbour(d);
                    if (neighbor != null && !pendingToVisit.contains(neighbor.Id) && !alreadyVisited.Contains(neighbor.Id)) {
                        pendingToVisit.queue(neighbor.Id, Random.Range(0, 100) < jitter ? 1 : 0);
                    }
                }
                
                if (cellTypes[current] == CellType.Grass)
                {
                    landBudget--;
                }
            }
            pendingToVisit.clear();
            alreadyVisited.Clear();
        }
        
        void createDeepWater()
        {
            List<int> pending = new List<int>();
            for (int i = 0; i < grid.Length; i++)
            {
                int randomDistance = Random.Range(3, 6);
                if (isDeepWater(randomDistance, i, ref pending))
                {
                    cellTypes[grid[i].Id] = CellType.DeepWater;
                }
                pending.Clear();
            }
        }

        bool isDeepWater(int loop, int id, ref List<int> pending)
        {
            pending.Add(id);
            if (cellTypes[id] > 0)
            {
                return false;
            }

            if (loop <= 0)
            {
                return true;
            }
            
            foreach (CellBase neighbour in grid[id].Neighbour)
            {
                if (neighbour == null || pending.Contains(neighbour.Id)) continue;
                if (!isDeepWater(loop - 1, neighbour.Id, ref pending))
                {
                    return false;
                }
            }

            return true;
        }

        void createFertileLand()
        {
            foreach (var id in getGrassCellByPercentage(fertileLandPopulation))
            {
                cellTypes[id] = CellType.Fertile;
            }
        }
        
        void createQuarry()
        {
            foreach (var id in getGrassCellByPercentage(quarryPopulation))
            {
                cellTypes[id] = CellType.Stone;
            }
        }
        
        void createForest()
        {
            foreach (var id in getGrassCellByPercentage(forestLevelPopulation))
            {
                List<int> pending = new List<int>();
                pending.Add(id);

                int current = 0;
                int total = Random.Range(3, 8);
                while (current < total && pending.Count > 0)
                {
                    int randomIndex = Random.Range(0, pending.Count);
                    int currentCell = pending[randomIndex];
                    pending.RemoveAt(randomIndex);

                    cellTypes[currentCell] = CellType.Forest;
                    
                    for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++) {
                        CellBase neighbor = grid[currentCell].getNeigbour(d);
                        if (neighbor != null && !pending.Contains(neighbor.Id) && cellTypes[neighbor.Id] == CellType.Grass) {
                            pending.Add(neighbor.Id);
                        }
                    }
                    current++;
                }
                pendingToVisit.clear();
            }
        }
        
        //TODO: create fishing area like fertile or quarry
        
        List<int> getGrassCellByPercentage(int percentage)
        {
            List<int> nonVisitedCellIndexes = new List<int>();
            for (int id = 0; id < cellTypes.Length; id++)
            {
                if (cellTypes[id] == CellType.Grass)
                {
                    nonVisitedCellIndexes.Add(id);
                }                
            }

            int numberOfCells = nonVisitedCellIndexes.Count * percentage / 100;

            List<int> grassCellIndexes = new List<int>();
            for (int i = 0; i < numberOfCells; i++)
            {
                //I know a cell can be added twice, but I think is good enough 
                grassCellIndexes.Add(nonVisitedCellIndexes[Random.Range(0, nonVisitedCellIndexes.Count)]);
            }
            
            return grassCellIndexes;
        }
    }
}
