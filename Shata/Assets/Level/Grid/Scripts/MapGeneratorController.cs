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
        LinkedList<int> pendingToVisit = new LinkedList<int>();
        List<int> alreadyVisited = new List<int>();

        [SerializeField] [Range(0,100)]  private float jitter;
        [SerializeField] [Range(20,60)]  private int minLandSize;
        [SerializeField] [Range(60,100)] private int maxLandSize;
        [SerializeField] [Range(4,10)]   private int landNumber;

        const float hexRadius = 0.866025404f;
        
        void Awake()
        {
            createEmptyMap(50, 50);
            for (int i = 0; i < landNumber; i++)
            {
                createTerrain(Random.Range(minLandSize, maxLandSize));
            }
            instantiateCells();
        }

        void createEmptyMap(int width, int height)
        {
            grid = new CellBase[height * width];
            
            for (int z = 0, i = 0; z < height; z++) {
                for (int x = 0; x < width; x++) {
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

            grid[id] = new CellBase(id, p, new Water());
        }

        void instantiateCells()
        {
            GameObject aux;
            for (int i = 0; i < grid.Length; i++)
            {
                aux = Instantiate<GameObject>(grid[i].CellType.getBasePrefab(), transform, false);
                aux.GetComponent<CellController>().CellBase = grid[i];
                aux.transform.localPosition = grid[i].Position;
            }
        }

        int getRandomCell()
        {
            return Random.Range(0, grid.Length);
        }

        void createTerrain(int size)
        {
            //get a not visited cell
            int index = 0;
            do
            {
                index = getRandomCell();
            } while (alreadyVisited.Contains(index));
            
            
            grid[index].CellType = new Grass();
            pendingToVisit.AddLast(index);
            
            index = 0;
            while (index < size && pendingToVisit.Count > 0) {
                int current = pendingToVisit.First.Value;
                pendingToVisit.RemoveFirst();
                alreadyVisited.Add(current);
                grid[current].CellType = new Grass();
                index += 1;

                for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++) {
                    CellBase neighbor = grid[current].getNeigbour(d);
                    if (neighbor != null && !alreadyVisited.Contains(neighbor.Id)) {
                        if (Random.Range(0, 100) < jitter)
                        {
                            pendingToVisit.AddFirst(neighbor.Id);
                        }
                        else
                        {
                            pendingToVisit.AddLast(neighbor.Id);
                        }
                        
                    }
                }
            }
            pendingToVisit.Clear();
        }
    }
}
