using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Variables;

namespace UI
{
    public class UIResourceManagerController : MonoBehaviour
    {
        [SerializeField] ResourceReference resourceReference;
        [SerializeField] Text text;


        private void Update()
        {
            text.text = resourceReference.amount.ToString("0");
        }
    }
}
