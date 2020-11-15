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
        [SerializeField] StorageReference storageReference;
        
        GameObject container;
    
        private void Start() {
            container = transform.GetChild(0).gameObject;
            container.SetActive(false);
            titleText.text = "Build";
        }
    
        public void selectedCellChangedEvent(CellReference cellReference)
        {
            bool isActive = cellReference.value != null && 
                            cellReference.value.CellBase.CellType.getAllowedBuilds().Any();
            
            container.SetActive(isActive);
            if (isActive) {
                foreach (Transform child in backgroundGrid.transform) Destroy(child.gameObject);
                foreach (var building in cellReference.value.CellBase.CellType.getAllowedBuilds())
                {
                    GameObject go = Instantiate(buttonPrefab, backgroundGrid.transform, false);
                    Button button = go.GetComponent<Button>();
                    Text textBox = button.GetComponentInChildren<Text>();
                    textBox.text = building.Title;
                    //TODO: create method to check if this can be build (enough wood) in storageReference
                    if (cellReference.value.CellBase.CellType.isEmptyCel() && storageReference.value.hasEnoughResources(building.Price))
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
            //TODO: create method to check if this can be build (enough wood) in storageReference
            if (cellReference.value.CellBase.CellType.isEmptyCel() && storageReference.value.hasEnoughResources(building.Price))
            {
                cellReference.value.CellBase.CellType.setCurrentBuilding(building);
                storageReference.value.AddModifier(building.Price);
                storageReference.value.AddModifier(building.Modifiers);
                cellReference.value.build();
            }
        }
    }
}
