﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;



//TODO: convertir esto en una clase sin logica, que solo responda a eventos varios y llame a lo que pertoca. Sera el CellReference
namespace Level.Grid
{
    //Cell manager. Is the entry point for events or references to update the cell status
    public class CellController : MonoBehaviour
    {
        CellOutlineController outline;
        private CellTypeInterface cell;
        [SerializeField] GameEvent selectedCellChangedEvent;
        [SerializeField] ResourceReference goldResourceReference;
        [SerializeField] ResourceReference foodResourceReference;
        [SerializeField] ResourceReference populationResourceReference;
        [SerializeField] ResourceReference woodResourceReference;

        public CellTypeInterface Cell
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
        
        public void build (BuildingInterface building)
        {
            cell.setCurrentBuilding(building);
            foodResourceReference.resource.AddModifier(building.FoodModifiers);
            goldResourceReference.resource.AddModifier(building.GoldModifiers);
            woodResourceReference.resource.AddModifier(building.WoodModifiers);
            populationResourceReference.resource.AddModifier(building.PopulationModifiers);
            woodResourceReference.resource.Amount -= building.Price;
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
