using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ConstructionPopOverController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        //TODO: Ideally this should be done by game events
        private ConstructionPanelController panelController;
        private string TextOnPopOver;
        private string TextOnPopOut;

        private void Start()
        {
            panelController = gameObject.GetComponentInParent<ConstructionPanelController>();
        }

        public void setPopOverText(string text)
        {
            TextOnPopOver = text;
        }
        
        public void setPopOutText(string text)
        {
            TextOnPopOut = text;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (panelController != null)
            {
                panelController.setTextObjectDescriptionEvent(TextOnPopOver);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (panelController != null)
            {    
                panelController.setTextObjectDescriptionEvent(TextOnPopOut);  
            }
        }
    }
}
