using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;



//TODO: convertir esto en una clase sin logica, que solo responda a eventos varios y llame a lo que pertoca. Sera el CellReference
namespace Level.Grid
{
    //Cell information related with unity behaviours
    public class CellController : MonoBehaviour
    {
        Outline outline;
        
        [SerializeField] CellReference cellReference;
        [SerializeField] GameEvent selectedCellChangedEvent;
        private CellTypeInterface cell;
        
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
        
        public void SetCell (CellTypeInterface c)
        {
            cell = c;
        }
    }
}
