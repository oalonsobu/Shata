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
        [SerializeField] Text popOverText;


        private void Start()
        {
            popOverImage.gameObject.SetActive(false);
        }

        private void Update()
        {
            text.text = resourceReference.resource.Amount.ToString("0") + "/" + resourceReference.resource.Storage.ToString("0");
            popOverText.text = "Production: " + resourceReference.resource.Production.ToString("0.00");
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
