using System;
using System.Collections.Generic;
using System.Linq;
using Level.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Variables;
using Random = UnityEngine.Random;

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
        [SerializeField] private MapReference mapReference; 
        
        private Grid grid;
        CustomCellLinkedList<int> pendingToVisit = new CustomCellLinkedList<int>();
        CellType[] cellTypes;
        
        [SerializeField]                  private GameObject panel;
        [SerializeField]                  private GameObject loadginText;
        
        [SerializeField]                  private InputField seedInput;
        [SerializeField]                  private Dropdown mapSizeInput;
        [SerializeField]                  private Slider jitterInput;
        [SerializeField]                  private Slider landPercentageInput;
        [SerializeField]                  private Slider stonePercentageInput;
        [SerializeField]                  private Slider fertilePercentageInput;
        [SerializeField]                  private Slider forestPercentageInput;
        
        [SerializeField] [Range(100,150)] private int minLandSize;
        [SerializeField] [Range(150,200)] private int maxLandSize;
        [SerializeField] [Range(5,10)]    private int mapBorderX;
        [SerializeField] [Range(5,10)]    private int mapBorderY;
        [SerializeField] [Range(0,2)]     private int mountainReduction;

        const float hexRadius = 0.866025404f;
        private const float maxElevation = 6;

        private void Start()
        {
            initInputs();
        }

        public void GenerateMapEvent()
        {
            loadginText.SetActive(true);
            panel.SetActive(false);
            MapSize mapSize = (MapSize) Enum.Parse(typeof(MapSize), mapSizeInput.options[mapSizeInput.value].text);
            initSeed();
            createEmptyMap((int) mapSize, (int) mapSize);
            createWorld();
            instantiateCells();
            mapReference.value = grid;
            SceneManager.LoadScene("Level1");
        }

        void initInputs()
        {
            loadginText.SetActive(false);
            string[] enumNames = Enum.GetNames(typeof(MapSize));
            mapSizeInput.AddOptions(new List<string>(enumNames));
            
            jitterInput.maxValue = 40;
            jitterInput.minValue = 10;
            jitterInput.wholeNumbers = true;
            
            landPercentageInput.maxValue = 90;
            landPercentageInput.minValue = 5;
            landPercentageInput.wholeNumbers = true;
            
            stonePercentageInput.maxValue = 10;
            stonePercentageInput.minValue = 5;
            stonePercentageInput.wholeNumbers = true;
            
            forestPercentageInput.maxValue = 10;
            forestPercentageInput.minValue = 5;
            forestPercentageInput.wholeNumbers = true;
            
            fertilePercentageInput.maxValue = 10;
            fertilePercentageInput.minValue = 5;
            fertilePercentageInput.wholeNumbers = true;
            
            seedInput.text = "1805286158"; //TODO: test purposes
            mapSizeInput.value = 1;
            mapSizeInput.RefreshShownValue();
            jitterInput.value = 15; //TODO: test purposes
            landPercentageInput.value = 45;//TODO: test purposes
            stonePercentageInput.value = 7;//TODO: test purposes
            forestPercentageInput.value = 7;//TODO: test purposes
            fertilePercentageInput.value = 7;//TODO: test purposes
        }

        void initSeed()
        {
            int seed = Int32.Parse(seedInput.text);
            if (seed == 0)
            {
                //it's a little strange to set the random seed with a random :P
                seed = Random.Range(0, int.MaxValue);
            }
            
            Random.InitState(seed);
        }

        void createEmptyMap(int width, int height)
        {
            grid = new Grid(width, height);
            cellTypes = new CellType[grid.Size];
            
            for (int z = 0, i = 0; z < grid.Height; z++) {
                for (int x = 0; x < grid.Width; x++)
                {
                    cellTypes[i] = 0;
                    createWaterCell(x, z, i);
                    grid.SetNeigbours(grid.Width, x, z, i);
                    i++;
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

            grid.SetCellBase(id, new CellBase(id, p));
            cellTypes[id] = CellType.Water;
        }

        void instantiateCells()
        {
            CellBase cell;
            for (int i = 0; i < grid.Size; i++)
            {
                cell = grid.GetCellBase(i);
                switch (cellTypes[cell.Id])
                {
                    case CellType n when n == CellType.DeepWater:
                        cell.CellType = new DeepWater();
                        break;
                    case CellType n when n == CellType.Water:
                        cell.CellType = new Water();
                        break;
                    case CellType n when n >= CellType.Grass && n <= CellType.Grass + mountainReduction:
                        cell.CellType = new Grass();
                        break;
                    case CellType n when n == CellType.LowMountain + mountainReduction:
                        cell.CellType = new LowMountain();
                        break;
                    case CellType n when n == CellType.Mountain + mountainReduction:
                        cell.CellType = new Mountain();
                        break;
                    case CellType n when n == CellType.HighMountain + mountainReduction:
                        cell.CellType = new HighMountain();
                        break;
                    case CellType n when n == CellType.Fertile:
                        cell.CellType = new Fertile();
                        break;
                    case CellType n when n == CellType.Forest:
                        cell.CellType = new Forest();
                        break;
                    case CellType n when n == CellType.Stone:
                        cell.CellType = new Stone();
                        break;
                    case CellType n when n == CellType.FishArea:
                        cell.CellType = new Water();
                        break;
                    default:
                        cell.CellType = new Fertile();
                        break;
                }
            }
        }

        int getRandomCell()
        {
            int x, maxX, minX, y, maxY, minY;
            minX = mapBorderX;
            minY = mapBorderY;
            maxX = grid.Width - mapBorderX;
            maxY = grid.Height - mapBorderY;
            x = Random.Range(minX, maxX);
            y = Random.Range(minY, maxY);
            return grid.GetCellBase(grid.Width * x + y).Id;
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
            int landBudget = Mathf.RoundToInt(grid.Size * landPercentageInput.value * 0.01f);
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
                    CellBase neighbor = grid.GetCellBase(current).getNeigbour(d);
                    if (neighbor != null && !pendingToVisit.contains(neighbor.Id) && !alreadyVisited.Contains(neighbor.Id)) {
                        pendingToVisit.queue(neighbor.Id, Random.Range(0, 100) < jitterInput.value ? 1 : 0);
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
            for (int i = 0; i < grid.Size; i++)
            {
                int randomDistance = Random.Range(3, 6);
                if (isDeepWater(randomDistance, i, ref pending))
                {
                    cellTypes[grid.GetCellBase(i).Id] = CellType.DeepWater;
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
            
            foreach (CellBase neighbour in grid.GetCellBase(id).Neighbour)
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
            foreach (var id in getGrassCellByPercentage((int) fertilePercentageInput.value))
            {
                cellTypes[id] = CellType.Fertile;
            }
        }
        
        void createQuarry()
        {
            foreach (var id in getGrassCellByPercentage((int) stonePercentageInput.value))
            {
                cellTypes[id] = CellType.Stone;
            }
        }
        
        void createForest()
        {
            foreach (var id in getGrassCellByPercentage((int) forestPercentageInput.value))
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
                        CellBase neighbor = grid.GetCellBase(currentCell).getNeigbour(d);
                        if (neighbor != null && !pending.Contains(neighbor.Id) && cellTypes[neighbor.Id] == CellType.Grass) {
                            pending.Add(neighbor.Id);
                        }
                    }
                    current++;
                }
                pendingToVisit.clear();
            }
        }
        
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
