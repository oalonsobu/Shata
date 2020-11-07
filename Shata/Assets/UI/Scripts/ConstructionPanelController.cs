using System.Linq;
using Level.Building;
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
        [SerializeField] ResourceReference woodReference;
        
        GameObject container;
    
        private void Start() {
            container = transform.GetChild(0).gameObject;
            container.SetActive(false);
            titleText.text = "Build";
        }
    
        public void selectedCellChangedEvent(CellReference cellReference)
        {
            bool isActive = cellReference.value != null && 
                            cellReference.value.Cell.getAllowedBuilds().Any();
            
            container.SetActive(isActive);
            if (isActive) {
                foreach (Transform child in backgroundGrid.transform) Destroy(child.gameObject);
                foreach (var building in cellReference.value.Cell.getAllowedBuilds())
                {
                    GameObject go = Instantiate(buttonPrefab, backgroundGrid.transform, false);
                    Button button = go.GetComponent<Button>();
                    Text textBox = button.GetComponentInChildren<Text>();
                    textBox.text = building.Title;
                    if (cellReference.value.Cell.canBeBuilt(building, woodReference.resource.Amount))
                    {
                        button.onClick.AddListener(()  => constructEvent(cellReference, building));
                        textBox.color = Color.white;
                    }
                    else
                    {
                        textBox.color = Color.red;
                    }
                }
            }
        }
        
        public void constructEvent(CellReference cellReference, BuildingInterface building)
        {
            //Check two avoid double clicks
            if (cellReference.value.Cell.canBeBuilt(building, woodReference.resource.Amount))
            {
                cellReference.value.build(building);
            }
        }
    }
}
