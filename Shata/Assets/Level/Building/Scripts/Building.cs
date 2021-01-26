using System;
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

        public abstract List<ResourceModifier> Price { get; }
        public abstract List<ResourceModifier> Modifiers { get; }

        public abstract List<Upgrade> Upgrades { get; }
        
        public GameObject getBasePrefab() {
            if (BasePrefab == "None")
            {
                throw new Exception();
            }
            return Resources.Load("Prefabs/" + BasePrefab + "lvl" + 1) as GameObject;
        }
        
        //TODO Move to another class
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

        public bool enoughResources(StorageManager storage)
        {
            return storage.hasEnoughResources(Price);
        }
        
        public bool isCompatibleWithCell(CellBase cell)
        {
            return (cell.isEmptyCell() && BuildableIn.Any(a=> a.GetType() == cell.CellType.GetType()));
        }
        
        //TODO: maybe we can store the reference in the building itself or something like that. I like this but I prefer the logic to be only in townhall
        public bool isBuildable(CellBase cell, StorageManager storage, bool townhallBuilt)
        {
            return assertConditions(cell) && isCompatibleWithCell(cell) && enoughResources(storage);
        }

        /*TODO: once the course is finished and if more buildings and conditions have been added,
         * I'd like to move this to other classes, kinda like the modifiers
         * I think that this is a powerful way since I can even change the BuildableIn property also
         * and all the logic will in this external classes and in the definition of conditions (maybe also the price?)
        */
        //Default condition, valid for almost every building
        protected virtual bool assertConditions(CellBase cell)
        {
            return closeToOtherBuilding(cell);
        }

        protected bool closeToOtherBuilding(CellBase cell)
        {
            return cell.Neighbour.Any(a=> !a.isEmptyCell());
        }
        
        protected bool closeToOtherBuilding<T>(CellBase cell)
        {
            return cell.Neighbour.Any(a=> a.CurrentBuilding.GetType().IsSubclassOf(typeof(T)));
        }
        
        protected bool closeToOtherCell<T>(CellBase cell)
        {
            return cell.Neighbour.Any(a=> a.CellType.GetType() == typeof(T));
        }
    }
}
