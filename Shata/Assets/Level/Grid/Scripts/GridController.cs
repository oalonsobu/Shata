using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Variables;

namespace Level.Grid
{
    //TODO: I think I need to separate the initialization and the "update" (the init method will grown)
    public class GridController : MonoBehaviour
    {
        //TODO: I think that maybe we can store a custom object, maybe something less consuming
        GameObject[] grid;
        [SerializeField] CellReference cellReference;
        [SerializeField] GameEvent selectedCellChangedEvent;

        const int gridHeight = 10;
        const int gridWidth  = 10;

        const float hexRadius = 0.866025404f;
        
        void Awake()
        {
            grid = new GameObject[gridHeight * gridWidth];
            
            for (int z = 0, i = 0; z < gridHeight; z++) {
                for (int x = 0; x < gridWidth; x++) {
                    initHex(x, z, i++);
                }
            }
        }
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                HandleInput();
            }
        }
        
                
        //TODO: this need to be improved. Is a little messed up...
        void initHex (int x, int z, int i) 
        {
            Vector3 position;
            int evenRow = z % 2; //1 or 0
            position.x = x + 0.5f * evenRow;
            position.y = 0f;
            position.z = z * hexRadius;

            CellTypeInterface cell = createCell();
            grid[i] = Instantiate<GameObject>(cell.getBasePrefab(), transform, false);
            grid[i].GetComponent<CellController>().Cell = cell;
            grid[i].transform.localPosition = position;
        }

        CellTypeInterface createCell()
        {
            int random = Random.Range(0, 10);
            //TODO: to improve, just testing
            CellTypeInterface cellType;
            if (random >= 0 && random <= 2) {
                cellType = new Water();
            } else if (random >= 3 && random <= 4) {
                cellType = new Farm();
            }
            else {
                cellType = new Grass();
            }
            return cellType;
        }
        
        void HandleInput () {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //If we are over a UI element, do not continue
                return;
            }
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (cellReference.value != null) {
                cellReference.value.removeOutline();
                cellReference.value = null;
                selectedCellChangedEvent.Raise();
            }
            if (Physics.Raycast(inputRay, out hit, 100.0f)) {
                if (hit.collider.CompareTag("Cell")) {
                    cellReference.value.addOutline();
                    cellReference.value = hit.transform.GetComponent<CellController>();
                    selectedCellChangedEvent.Raise();
                }
            }
        }
    }
}
