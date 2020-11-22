using Level.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using Variables;

namespace Level.Grid
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] CellReference cellReference;
        [SerializeField] GameEvent selectedCellChangedEvent;
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                HandleInput();
            }
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
                    cellReference.value = hit.transform.GetComponent<CellController>();
                    cellReference.value.addOutline();
                    selectedCellChangedEvent.Raise();
                }
            }
        }
    }
}
