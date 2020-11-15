using Level.Cell;
using UnityEngine;
using UnityEngine.UI;
using Variables;

namespace UI
{
    public class BuildingTypePanelController : MonoBehaviour
    {
    
        [SerializeField] Text titleText;
        [SerializeField] Text descriptionText;
        [SerializeField] Text commentText;
      
        GameObject container;
    
        private void Start() {
            container = transform.GetChild(0).gameObject;
            container.SetActive(false);
        }
    
        public void selectedCellChangedEvent(CellReference cellReference)
        {
            bool isActive = cellReference.value != null && 
                            !(cellReference.value.CellBase.CellType is Water);
            container.SetActive(isActive);
            if (isActive) {
                titleText.text = cellReference.value.CellBase.CellType.CurrentBuilding.Title;
                descriptionText.text = cellReference.value.CellBase.CellType.CurrentBuilding.Description;
                commentText.text = cellReference.value.CellBase.CellType.CurrentBuilding.Comment;
                
            }
        }
    }
}
