using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Level.Cell;
using Level.Resource;
using UnityEngine;

namespace Level.Building
{

    public abstract class Building
    {
        public abstract string Description { get; }
        public abstract string Comment { get; }
        public abstract string Title { get; }
        public abstract string BasePrefab { get; }
        public abstract List<CellTypeInterface> BuildableIn { get; }
        
        //Is a list cause maybe we want a building to be upgrade to more than one building
        public abstract List<Building> UpgradableTo { get; }
        
        public abstract List<ResourceModifier> Price { get; }
        public abstract List<ResourceModifier> Modifiers { get; }
        
        public abstract int CurrentLvl { get; }
        
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
        
        public bool isBuildable(CellBase cell)
        {
            return (cell.isEmptyCell() && BuildableIn.Any(a=> a.GetType() == cell.CellType.GetType())) ||
                   (!cell.isEmptyCell() && cell.CurrentBuilding.UpgradableTo.Any(a=> a.GetType() == GetType()));
        }
        
        public bool isBuildable(CellBase cell, StorageManager storage)
        {
            return isBuildable(cell) && storage.hasEnoughResources(Price);
        }
    }
}
