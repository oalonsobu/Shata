using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Level.Building;
using Level.Cell;
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
        
        List<Building> buildings = new List<Building>();
    
        private void Start() {
            container = transform.GetChild(0).gameObject;
            container.SetActive(false);
        }
    
        public void selectedCellChangedEvent(CellReference cellReference)
        {
            if (cellReference.value == null) return;
            
            getAllAvailableBuilding(cellReference.value.CellBase);
            bool isActive = buildings.Any() || !cellReference.value.CellBase.isEmptyCell();
            container.SetActive(isActive);
            
            if (isActive)
            {
                clearObjects();

                if (cellReference.value.CellBase.isEmptyCell())
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
            
            titleText.text = "Build";
            setTextObjectDescriptionEvent(cellReference.value.CellBase.CurrentBuilding.Comment);
            
            foreach (Building building in buildings)
            {
                GameObject go = Instantiate(buttonPrefab, buildingLayout.transform, false);
                Button button = go.GetComponent<Button>();
                Text textBox = button.GetComponentInChildren<Text>();
                textBox.text = building.Title;

                if (building.isBuildable(cellReference.value.CellBase, storageReference.value))
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
                cpoc.setPopOverText(text);
                cpoc.setPopOutText(cellReference.value.CellBase.CurrentBuilding.Comment);
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
            foreach (Building building in cellReference.value.CellBase.CurrentBuilding.UpgradableTo)
            {
                go = Instantiate(buttonPrefab, buildingLayout.transform, false);
                button = go.GetComponent<Button>();
                        
                textBox = button.GetComponentInChildren<Text>();
                textBox.text = "Update";
                
                if (building.isBuildable(cellReference.value.CellBase, storageReference.value))
                {
                    button.onClick.AddListener(()  => updateBuildingEvent(cellReference, building));
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
                cpoc.setPopOverText(text);
                cpoc.setPopOutText(cellReference.value.CellBase.CurrentBuilding.Comment);
            }
        }

        private void constructEvent(CellReference cellReference, Building building)
        {
            //Check two avoid double clicks
            if (building.isBuildable(cellReference.value.CellBase, storageReference.value))
            {
                cellReference.value.CellBase.setCurrentBuilding(building);
                storageReference.value.AddModifier(cellReference.value.CellBase.Id, building.Price);
                storageReference.value.AddModifier(cellReference.value.CellBase.Id, building.Modifiers);
                cellReference.value.build();
            } 
        }
        
        private void removeBuildingEvent(CellReference cellReference)
        {
            //Check to avoid double clicks
            if (!cellReference.value.CellBase.isEmptyCell())
            {
                storageReference.value.RemoveModifier(cellReference.value.CellBase.Id, cellReference.value.CellBase.CurrentBuilding.Modifiers);
                cellReference.value.CellBase.setCurrentBuilding(new None());
                cellReference.value.demolish();
            }
        }
        
        private void updateBuildingEvent(CellReference cellReference, Building building)
        {
            //Check to avoid double clicks
            if (!cellReference.value.CellBase.isEmptyCell())
            {
                removeBuildingEvent(cellReference);
                constructEvent(cellReference, building);
            }
        }

        public void setTextObjectDescriptionEvent(string text)
        {
            Text textBox = descriptionPrefab.GetComponent<Text>();
            textBox.text = text;
        }

        public void getAllAvailableBuilding(CellBase cell)
        {
            buildings.Clear();
            foreach (Type type in Assembly.GetAssembly(typeof(Building)).GetTypes().Where
            (
                myType =>
                    myType.IsClass &&
                    !myType.IsAbstract &&
                    myType.IsSubclassOf(typeof(Building)) &&
                    myType != typeof(None)
            ))
            {
                Building b = (Building) Activator.CreateInstance(type);
                if (b.isCompatibleWithCell(cell))
                {
                    if (b.CurrentLvl == 1)
                    {
                        buildings.Add(b);
                    }
                }
            }
        }
    }
}
