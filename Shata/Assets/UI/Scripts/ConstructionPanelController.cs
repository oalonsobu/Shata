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
        [SerializeField] GridLayoutGroup buildingLayout;
        [SerializeField] GameObject buttonPrefab;
        [SerializeField] GameObject descriptionPrefab;
        [SerializeField] StorageReference storageReference;
        
        GameObject container;
    
        private void Start() {
            container = transform.GetChild(0).gameObject;
            container.SetActive(false);
        }
    
        public void selectedCellChangedEvent(CellReference cellReference)
        {
            bool isActive = cellReference.value != null && 
                            cellReference.value.CellBase.CellType.getAllowedBuilds().Any();
            container.SetActive(isActive);
            
            if (isActive) {
                foreach (Transform child in buildingLayout.transform) Destroy(child.gameObject);

                if (cellReference.value.CellBase.CellType.CurrentBuilding is None)
                {
                    foreach (var building in cellReference.value.CellBase.CellType.getAllowedBuilds())
                    {
                        titleText.text = "Build";
                        descriptionPrefab.SetActive(false);
                        
                        GameObject go = Instantiate(buttonPrefab, buildingLayout.transform, false);
                        Button button = go.GetComponent<Button>();
                        Text textBox = button.GetComponentInChildren<Text>();
                        textBox.text = building.Title;

                        if (cellReference.value.CellBase.CellType.isEmptyCell() && storageReference.value.hasEnoughResources(building.Price))
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
                else
                {
                    titleText.text = cellReference.value.CellBase.CellType.CurrentBuilding.Title;
                    descriptionPrefab.SetActive(true);
                    Text text = descriptionPrefab.GetComponent<Text>();
                    text.text = cellReference.value.CellBase.CellType.CurrentBuilding.Description;
                    
                    //Remove button
                    GameObject go = Instantiate(buttonPrefab, buildingLayout.transform, false);
                    Button button = go.GetComponent<Button>();
                    button.onClick.AddListener(()  => removeBuildingEvent(cellReference));
                    
                    Text textBox = button.GetComponentInChildren<Text>();
                    textBox.text = "Remove";
                    textBox.color = Color.white;
                    
                    //Update button
                    go = Instantiate(buttonPrefab, buildingLayout.transform, false);
                    button = go.GetComponent<Button>();
                    button.onClick.AddListener(()  => updateBuildingEvent(cellReference));
                    
                    textBox = button.GetComponentInChildren<Text>();
                    textBox.text = "Update";
                    textBox.color = Color.white;
                }
                
            }
        }

        private void constructEvent(CellReference cellReference, BuildingInterface building)
        {
            //Check two avoid double clicks
            if (cellReference.value.CellBase.CellType.isEmptyCell() && storageReference.value.hasEnoughResources(building.Price))
            {
                cellReference.value.CellBase.CellType.setCurrentBuilding(building);
                storageReference.value.AddModifier(building.Price);
                storageReference.value.AddModifier(building.Modifiers);
                cellReference.value.build();
            } 
        }
        
        private void removeBuildingEvent(CellReference cellReference)
        {
            //Check two avoid double clicks
            if (!cellReference.value.CellBase.CellType.isEmptyCell())
            {
                cellReference.value.CellBase.CellType.setCurrentBuilding(new None());
                //Remove Modifiers
                cellReference.value.demolish();
            }
        }
        
        private void updateBuildingEvent(CellReference cellReference)
        {
            Debug.Log("Not implemented yet");
        }
    }
}
