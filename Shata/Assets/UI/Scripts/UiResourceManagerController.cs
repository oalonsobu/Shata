﻿using System;
using Level.Resource;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Variables;

namespace UI
{
    public class UiResourceManagerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] StorageReference storageReference;
        [SerializeField] ResourceType resourceType; 
        [SerializeField] Sprite resourceImage;
        [SerializeField] Text text;
        [SerializeField] GameObject popOverImage;
        [SerializeField] Text popOverText;


        private void Start()
        {
            popOverImage.gameObject.SetActive(false);
            transform.Find("Icon").GetComponent<Image>().sprite = resourceImage;
        }

        private void Update()
        {
            Resource resource = null;
            switch (resourceType)
            {
                case ResourceType.Gold:
                    resource = storageReference.value.Gold;
                    break;
                case ResourceType.Wood:
                    resource = storageReference.value.Wood;
                    break;
                case ResourceType.Meat:
                    resource = storageReference.value.Meat;
                    break;
                case ResourceType.Stone:
                    resource = storageReference.value.Stone;
                    break;
                case ResourceType.Population:
                    resource = storageReference.value.Population;
                    break;
            }

            if (resource != null)
            {
                text.text = Math.Floor(resource.Amount).ToString("0") + "/" + resource.Storage.ToString("0");
                popOverText.text = "Production: " + resource.Production.ToString("0.00");
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            popOverImage.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            popOverImage.SetActive(false);
        }
    }
}
