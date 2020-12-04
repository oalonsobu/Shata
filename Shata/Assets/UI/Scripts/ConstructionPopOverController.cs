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
        private string Text;
        private void Start()
        {
             panelController = gameObject.GetComponentInParent<ConstructionPanelController>();
        }

        public void setText(string text)
        {
            Text = text;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (panelController != null)
            {
                panelController.setTextObjectDescriptionEvent(Text);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (panelController != null)
            {    
                panelController.setTextObjectDescriptionEvent("");  
            }
        }
    }
}
