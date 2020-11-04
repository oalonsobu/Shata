using System.Linq;
using Level.Grid;
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
            bool isActive = cellReference.value != null && cellReference.value.Cell.getAllowedBuilds().Any();
            container.SetActive(isActive);
            if (isActive) {
                titleText.text = cellReference.value.Cell.CurrentBuilding.Title;
                descriptionText.text = cellReference.value.Cell.CurrentBuilding.Description;
                commentText.text = cellReference.value.Cell.CurrentBuilding.Comment;
                
            }
        }
    }
}
