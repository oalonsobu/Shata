using System;
using System.Collections;
using System.Collections.Generic;
using Level.Resource;
using UnityEngine;

namespace Level.Building
{

    public abstract class BuildingInterface
    {
        public abstract List<ResourceModifier> Price { get; }
        public abstract string Description { get; }
        public abstract string Comment { get; }
        public abstract string Title { get; }
        public abstract string BasePrefab { get; }
        
        public abstract List<ResourceModifier> Modifiers { get; }
        
        public int CurrentLvl { get; set; }
        
        public GameObject getBasePrefab() {
            if (BasePrefab == "None")
            {
                throw new Exception();
            }
            return Resources.Load("Prefabs/" + BasePrefab + "lvl" + CurrentLvl) as GameObject;
        }

        public string PriceToString()
        {
            string text = "";
            foreach (var resourceModifier in Price)
            {
                text += resourceModifier.ResourceType.ToString() + ": " + resourceModifier.Amount + "  ";
            }

            if (text == "")
            {
                text = "Price: Free";
            }

            return text;
        }
    }
}
