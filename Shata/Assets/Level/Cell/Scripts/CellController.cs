using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
using Level.Building;


//TODO: convertir esto en una clase sin logica, que solo responda a eventos varios y llame a lo que pertoca. Sera el CellReference
namespace Level.Cell
{
    //Cell manager. Is the entry point for events or references to update the cell status
    public class CellController : MonoBehaviour
    {
        CellOutlineController outline;
        private CellInterface cell;
        [SerializeField] GameEvent selectedCellChangedEvent;
        [SerializeField] StorageReference storageReference;

        public CellInterface Cell
        {
            get => cell;
            set => cell = value;
        }

        void Start() {
            outline = gameObject.AddComponent<CellOutlineController>();
        }
        
        public void addOutline () {
            outline.enable();
        }
        
        public void removeOutline ()
        {
            outline.disable();
        }
        
        public void build ()
        {
            instantiateBuilding();
            selectedCellChangedEvent.Raise();
        }

        private void instantiateBuilding()
        {
            GameObject building = Instantiate<GameObject>(cell.CurrentBuilding.getBasePrefab(), transform, false);
            building.transform.Rotate(new Vector3(0,1,0), 90);
        }
    }
}
