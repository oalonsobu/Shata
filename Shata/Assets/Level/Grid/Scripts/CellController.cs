using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Level.Grid
{
    //Cell information related with unity behaviours
    public class CellController : MonoBehaviour
    {
        Outline outline;
        
        //TODO: need one for active :D
        [SerializeField] CellReference cellReference;
        [SerializeField] BoolReference isActiveCelReference;


        //TODO: randomize, just for testing rn
        public Cell cell = new Cell(new Grass());
        
        void Start() {
            outline = GetComponent<Outline>();
            outline.enabled = false;
        }
        
        public GameObject SelectCell () {
            outline.enabled = true;
            isActiveCelReference.value = true;
            cellReference.value = cell;
            
            return gameObject;
        }
        
        public void UnselectCell () {
            cellReference.value = null;
            outline.enabled = false;
            isActiveCelReference.value = false;
        }
    }
}
