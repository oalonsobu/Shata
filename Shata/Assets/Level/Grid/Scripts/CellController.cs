using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Grid
{
    public class CellController : MonoBehaviour
    {
        Outline outline;
        
        void Start()
        {
            outline = GetComponent<Outline>();
            outline.enabled = false;
        }
        
        public GameObject SelectCell () {
            outline.enabled = true;
            
            return gameObject;
        }
        
        public void UnselectCell () {
            outline.enabled = false;
        }
    }
}
