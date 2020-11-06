using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Variables;

namespace UI
{
    public class UiResourceManagerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] ResourceReference resourceReference;
        [SerializeField] Text text;
        [SerializeField] Image popOverImage;
        [SerializeField] Text popOvertext;


        private void Start()
        {
            popOverImage.gameObject.SetActive(false);
        }

        private void Update()
        {
            float production = resourceReference.resource.ApplyModifier();
            text.text = resourceReference.resource.Amount.ToString("0");
            popOvertext.text = "Production: " + production.ToString("0.00");
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            popOverImage.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            popOverImage.gameObject.SetActive(false);
        }
    }
}
