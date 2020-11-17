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

    public static class HexDirectionExtensions {

        public static HexDirection Opposite (this HexDirection direction) {
            return (int)direction < 3 ? (direction + 3) : (direction - 3);
        }
    }
    
    //TODO: I think I need to separate the initialization and the "update" (the init method will grown)
    public class MapGeneratorController : MonoBehaviour
    {
        //TODO: I think that maybe we can store a custom object, maybe something less consuming
        CellBase[] grid;
        CustomCellLinkedList<int> pendingToVisit = new CustomCellLinkedList<int>();
        int[] timesVisited;

        [SerializeField] [Range(0,100)]  private float jitter;
        [SerializeField] [Range(20,60)]  private int minLandSize;
        [SerializeField] [Range(60,100)] private int maxLandSize;
        [SerializeField] [Range(5,95)]   private int landPercentage;

        const float hexRadius = 0.866025404f;
        
        void Awake()
        {
            createEmptyMap(50, 50);
            createWorld();
            instantiateCells();
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
                    case 0:
                        grid[i].CellType = new Water();
                        break;
                    case 1:
                        grid[i].CellType = new Grass();
                        break;
                    default:
                        grid[i].CellType = new Farm();
                        break;
                }
                Debug.Log(timesVisited[grid[i].Id]);
                aux = Instantiate<GameObject>(grid[i].CellType.getBasePrefab(), transform, false);
                aux.GetComponent<CellController>().CellBase = grid[i];
                aux.transform.localPosition = grid[i].Position;
            }
        }

        int getRandomCell()
        {
            return Random.Range(0, grid.Length);
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
            while (landBudget >= 0)
            {
                createTerrain(Random.Range(minLandSize, maxLandSize),ref landBudget);
            }
        }

        void createTerrain(int size, ref int landBudget)
        {
            int currentSize = 0;
            int cell = getNotVisitedRandomCell();
            pendingToVisit.queue(cell, 1);
            
            while (pendingToVisit.Count > 0)
            {
                int current = pendingToVisit.dequeue();
                timesVisited[current]++;
                if (timesVisited[current] == 1)
                {
                    landBudget--;
                    currentSize += 1;
                    if (landBudget == 0 || currentSize >= size) break;
                }

                for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++) {
                    CellBase neighbor = grid[current].getNeigbour(d);
                    if (neighbor != null && !pendingToVisit.contains(neighbor.Id)) {
                        pendingToVisit.queue(neighbor.Id, Random.Range(0, 100) < jitter ? 1 : 0);
                    }
                }
            }
            pendingToVisit.clear();
        }
    }
}
