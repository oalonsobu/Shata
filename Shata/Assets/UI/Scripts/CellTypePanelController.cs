﻿using Level.Grid;
using UnityEngine;
using UnityEngine.UI;
using Variables;

namespace UI
{
    public class CellTypePanelController : MonoBehaviour
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
            bool isActive = cellReference.value != null;
            container.SetActive(isActive);
            if (isActive) {
                titleText.text = cellReference.value.CellBase.CellType.Title;
                descriptionText.text = cellReference.value.CellBase.CellType.Description;
                commentText.text = cellReference.value.CellBase.CellType.Comment;
                
            }
        }
    }
}
