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
        
        [SerializeField] CellReference cellReference;
        [SerializeField] GameEvent selectedCellChangedEvent;


        //TODO: randomize, just for testing rn
        public Cell cell = new Cell(new Grass());
        
        void Start() {
            outline = GetComponent<Outline>();
            outline.enabled = false;
        }
        
        public GameObject SelectCell () {
            outline.enabled = true;
            cellReference.value = cell;
            selectedCellChangedEvent.Raise();
            
            return gameObject;
        }
        
        public void UnselectCell () {
            cellReference.value = null;
            outline.enabled = false;
            selectedCellChangedEvent.Raise();
        }
    }
}
