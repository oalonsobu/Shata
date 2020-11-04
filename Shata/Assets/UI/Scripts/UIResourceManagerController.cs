using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Variables;

namespace UI
{
    public class UIResourceManagerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
            text.text = resourceReference.amount.ToString("0");
            popOvertext.text = "Amount: " + resourceReference.amount.ToString("0.0") + 
                               "\nProduction " + resourceReference.increment.ToString("0.0");
            
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
