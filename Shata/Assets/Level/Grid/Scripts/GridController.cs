using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Level.Grid
{

    public class GridController : MonoBehaviour
    {
        [SerializeField] GameObject cellPrefab;

        //TODO: I think that maybe we can store a custom object, maybe something less consuming
        GameObject[] grid;
        GameObject selectedCell;

        const int gridHeight = 10;
        const int gridWidth  = 10;

        const float hexRadius = 0.866025404f;
        
        void Awake()
        {
            selectedCell = null;
            
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
        
                
        void initHex (int x, int z, int i) {
            Vector3 position;
            int evenRow = z % 2; //1 or 0
            position.x = x + 0.5f * evenRow;
            position.y = 0f;
            position.z = z * hexRadius;
    
            GameObject cell = grid[i] = Instantiate<GameObject>(cellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
        }
        
        void HandleInput () {
            if (selectedCell != null) {
                selectedCell.GetComponent<CellController>().UnselectCell();
            }
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit, 100.0f)) {
                if (hit.collider.CompareTag("Cell")) {
                    CellController cellController = hit.collider.gameObject.GetComponent<CellController>();
                    selectedCell = cellController.SelectCell();
                }
            }
        }
    }
}
