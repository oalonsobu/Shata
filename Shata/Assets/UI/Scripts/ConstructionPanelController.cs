using System.Collections.Generic;
using System.Linq;
using Level.Grid;
using UnityEngine;
using UnityEngine.UI;
using Variables;

namespace UI
{
    public class ConstructionPanelController : MonoBehaviour
    {
    
        [SerializeField] Text titleText;
        [SerializeField] GridLayoutGroup backgroundGrid;
        [SerializeField] GameObject buttonPrefab;
      
        GameObject container;
    
        private void Start() {
            container = transform.GetChild(0).gameObject;
            container.SetActive(false);
            titleText.text = "Build";
        }
    
        public void selectedCellChangedEvent(CellReference cellReference)
        {
            bool isActive = cellReference.value != null && 
                            cellReference.value.Cell.AllowedBuildings.Any() && 
                            cellReference.value.Cell.CurrentBuilding is None;
            
            container.SetActive(isActive);
            if (isActive) {
                foreach (Transform child in backgroundGrid.transform) Destroy(child.gameObject);
                foreach (var buildingInterface in cellReference.value.Cell.AllowedBuildings)
                {
                    GameObject go = Instantiate(buttonPrefab, backgroundGrid.transform, false);
                    Button button = go.GetComponent<Button>();
                    button.onClick.AddListener(()  => constructEvent(cellReference, buildingInterface));
                    Text textBox = button.GetComponentInChildren<Text>();
                    textBox.text = buildingInterface.Title;
                }
            }
        }
        
        public void constructEvent(CellReference cellReference, BuildingInterface building)
        {
            //Check two avoid double clicks
            if (cellReference.value.Cell.CurrentBuilding is None)
            {
                cellReference.value.build(building);
            }
        }
    }
}
