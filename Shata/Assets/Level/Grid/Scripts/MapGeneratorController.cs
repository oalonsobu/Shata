using System.Collections.Generic;
using Level.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using Variables;

namespace Level.Grid
{
    public enum HexDirection {
        NE, E, SE, SW, W, NW
    }

    public enum MapSize {
        Small, Medium, Large
    }
    
    //TODO: I think I need to separate the initialization and the "update" (the init method will grown)
    public class MapGeneratorController : MonoBehaviour
    {
        Dictionary<MapSize, Vector2> MapSizeConvert = new Dictionary<MapSize, Vector2>()
        {
            {MapSize.Small, new Vector2(30,30)},
            {MapSize.Medium, new Vector2(50,50)},
            {MapSize.Large, new Vector2(70,70)}
        };
        
        //TODO: I think that maybe we can store a custom object, maybe something less consuming
        CellBase[] grid;
        CustomCellLinkedList<int> pendingToVisit = new CustomCellLinkedList<int>();
        int[] timesVisited;

        [SerializeField]                  private int seed;
        [SerializeField]                  private MapSize mapSize = MapSize.Small;
        [SerializeField] [Range(10,40)]   private float jitter;
        [SerializeField] [Range(100,150)] private int minLandSize;
        [SerializeField] [Range(150,200)] private int maxLandSize;
        [SerializeField] [Range(5,95)]    private int landPercentage;
        [SerializeField] [Range(5,10)]    private int mapBorderX;
        [SerializeField] [Range(5,10)]    private int mapBorderY;
        [SerializeField] [Range(0,2)]     private int mountainReduction;

        const float hexRadius = 0.866025404f;
        private const float maxElevation = 6;
        
        void Awake()
        {
            initSeed();
            createEmptyMap((int) MapSizeConvert[mapSize].x, (int) MapSizeConvert[mapSize].y);
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
            //Todo: transform to unique array with both values
            grid = new CellBase[height * width];
            timesVisited = new int[height * width];
            
            for (int z = 0, i = 0; z < height; z++) {
                for (int x = 0; x < width; x++)
                {
                    timesVisited[i] = 0;
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
            timesVisited[id] = 0;
        }

        void instantiateCells()
        {
            GameObject aux;
            for (int i = 0; i < grid.Length; i++)
            {
                switch (timesVisited[grid[i].Id])
                {
                    case int n when n == -1:
                        grid[i].CellType = new DeepWater();
                        break;
                    case int n when n == 0:
                        grid[i].CellType = new Water();
                        break;
                    case int n when n >= 1 && n <= 1 + mountainReduction:
                        grid[i].CellType = new Grass();
                        break;
                    case int n when n == 2 + mountainReduction:
                        grid[i].CellType = new Stone();
                        break;
                    case int n when n == 3 + mountainReduction:
                        grid[i].CellType = new Mountain();
                        break;
                    case int n when n == 4 + mountainReduction:
                        grid[i].CellType = new HighMountain();
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
            maxX = (int) MapSizeConvert[mapSize].x - mapBorderX;
            maxY = (int) MapSizeConvert[mapSize].y - mapBorderY;
            x = Random.Range(minX, maxX);
            y = Random.Range(minY, maxY);
            return grid[(int) MapSizeConvert[mapSize].x * x + y].Id;
        }
        
        int getNotVisitedRandomCell()
        {
            int cell = 0;
            do
            {
                cell = getRandomCell();
            } while (timesVisited[cell] != 0);

            return cell;
        }

        void createWorld()
        {
            int landBudget = Mathf.RoundToInt(grid.Length * landPercentage * 0.01f);
            while (landBudget > 0)
            {
                upriseTerrain(Random.Range(minLandSize, maxLandSize),ref landBudget);
            }

            createDeepWater();
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
                if (timesVisited[current] < maxElevation)
                {
                    timesVisited[current]++;
                }

                for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++) {
                    CellBase neighbor = grid[current].getNeigbour(d);
                    if (neighbor != null && !pendingToVisit.contains(neighbor.Id) && !alreadyVisited.Contains(neighbor.Id)) {
                        pendingToVisit.queue(neighbor.Id, Random.Range(0, 100) < jitter ? 1 : 0);
                    }
                }
                
                if (timesVisited[current] == 1)
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
                    timesVisited[grid[i].Id] = -1;
                }
                pending.Clear();
            }
        }

        bool isDeepWater(int loop, int id, ref List<int> pending)
        {
            pending.Add(id);
            if (timesVisited[id] > 0)
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
    }
}
