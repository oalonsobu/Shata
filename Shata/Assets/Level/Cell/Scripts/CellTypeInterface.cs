using UnityEngine;
using System.Collections.Generic;
using Level.Building;
using Level.Grid;
using Level.Resource;

namespace Level.Cell
{
     //No unity logic, only events and reference
    public abstract class CellTypeInterface
    {
        public abstract string Description { get; }
        public abstract string Comment { get; }
        public abstract string Title { get; }
        public abstract string BasePrefab { get; }
        public abstract List<Building.Building> AllowedBuildings { get; }
        
        //TODO: check for errors?
        public GameObject getBasePrefab() {
            return Resources.Load("Prefabs/" + BasePrefab) as GameObject;
        }

        public List<Building.Building> getAllowedBuilds()
        {
            return AllowedBuildings;
        }
    }
}
