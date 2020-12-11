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
        [SerializeField] HorizontalLayoutGroup buildingLayout;
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
            
            if (isActive)
            {
                clearObjects();
                titleText.text = "Build";
                setTextObjectDescriptionEvent("");

                if (cellReference.value.CellBase.CurrentBuilding is None)
                {
                     setBuildPanel(cellReference);
                }
                else
                {
                    setUpgradePanel(cellReference);
                }
                
            }
        }

        private void clearObjects()
        {
            foreach (Transform child in buildingLayout.transform)
            {
                Destroy(child.gameObject);
            }
        }
        
        private void setBuildPanel(CellReference cellReference)
        {
            foreach (var building in cellReference.value.CellBase.CellType.getAllowedBuilds())
            {
                GameObject go = Instantiate(buttonPrefab, buildingLayout.transform, false);
                Button button = go.GetComponent<Button>();
                Text textBox = button.GetComponentInChildren<Text>();
                textBox.text = building.Title;

                if (cellReference.value.CellBase.isEmptyCell() && storageReference.value.hasEnoughResources(building.Price))
                {
                    button.onClick.AddListener(()  => constructEvent(cellReference, building));
                    textBox.color = Color.white;
                }
                else
                {
                    textBox.color = Color.red;
                }

                ConstructionPopOverController cpoc = button.gameObject.GetComponent<ConstructionPopOverController>();
                string text = "";
                text += building.Description + '\n' + building.Comment + '\n';
                text += building.PriceToString();
                cpoc.setText(text);
            }
        }
        
        private void setUpgradePanel(CellReference cellReference)
        {
            titleText.text = cellReference.value.CellBase.CurrentBuilding.Title;
            setTextObjectDescriptionEvent(cellReference.value.CellBase.CurrentBuilding.Comment);
                    
            //Remove button
            GameObject go = Instantiate(buttonPrefab, buildingLayout.transform, false);
            Button button = go.GetComponent<Button>();
            button.onClick.AddListener(()  => removeBuildingEvent(cellReference));
            button.gameObject.GetComponent<ConstructionPopOverController>().enabled = false;

            Text textBox = button.GetComponentInChildren<Text>();
            textBox.text = "Remove";
            textBox.color = Color.white;
                    
            //Update button
            go = Instantiate(buttonPrefab, buildingLayout.transform, false);
            button = go.GetComponent<Button>();
            button.onClick.AddListener(()  => updateBuildingEvent(cellReference));
            button.gameObject.GetComponent<ConstructionPopOverController>().enabled = false;
                    
            textBox = button.GetComponentInChildren<Text>();
            textBox.text = "Update";
            textBox.color = Color.white;
        }

        private void constructEvent(CellReference cellReference, BuildingInterface building)
        {
            //Check two avoid double clicks
            if (cellReference.value.CellBase.isEmptyCell() && storageReference.value.hasEnoughResources(building.Price))
            {
                cellReference.value.CellBase.setCurrentBuilding(building);
                storageReference.value.AddModifier(building.Price);
                storageReference.value.AddModifier(building.Modifiers);
                cellReference.value.build();
            } 
        }
        
        private void removeBuildingEvent(CellReference cellReference)
        {
            //Check two avoid double clicks
            if (!cellReference.value.CellBase.isEmptyCell())
            {
                storageReference.value.RemoveModifier(cellReference.value.CellBase.CurrentBuilding.Modifiers);
                cellReference.value.demolish();
                cellReference.value.CellBase.setCurrentBuilding(new None());
            }
        }
        
        private void updateBuildingEvent(CellReference cellReference)
        {
            Debug.Log("Not implemented yet");
        }

        public void setTextObjectDescriptionEvent(string text)
        {
            Text textBox = descriptionPrefab.GetComponent<Text>();
            textBox.text = text;
        }
    }
}
