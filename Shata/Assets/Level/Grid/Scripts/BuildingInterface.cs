using System;
using System.Collections;
using System.Collections.Generic;
using Level.Extra;
using UnityEngine;

namespace Level.Grid
{

    public abstract class BuildingInterface
    {
        public abstract int Price { get; }
        public abstract string Description { get; }
        public abstract string Comment { get; }
        public abstract string Title { get; }
        public abstract string BasePrefab { get; }
        
        public abstract List<ResourceModifier> GoldModifiers { get; }
        public abstract List<ResourceModifier> WoodModifiers { get; }
        public abstract List<ResourceModifier> FoodModifiers { get; }
        public abstract List<ResourceModifier> PopulationModifiers { get; }
        
        public int CurrentLvl { get; set; }
        
        public GameObject getBasePrefab() {
            if (BasePrefab == "None")
            {
                throw new Exception();
            }
            return Resources.Load("Prefabs/" + BasePrefab + "lvl" + CurrentLvl) as GameObject;
        }
    }
}
