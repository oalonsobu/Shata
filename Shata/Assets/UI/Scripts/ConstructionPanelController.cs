﻿using System.Linq;
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
                foreach (Transform child in buildingLayout.transform) Destroy(child.gameObject);
                foreach (var building in cellReference.value.CellBase.CellType.getAllowedBuilds())
                {
                    GameObject go = Instantiate(buttonPrefab, buildingLayout.transform, false);
                    Button button = go.GetComponent<Button>();
                    Text textBox = button.GetComponentInChildren<Text>();
                    textBox.text = building.Title;

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
