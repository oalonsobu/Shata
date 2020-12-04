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
        public abstract List<BuildingInterface> AllowedBuildings { get; }

        public BuildingInterface CurrentBuilding { get; set; } = new None();

        //TODO: check for errors?
        public GameObject getBasePrefab() {
            return Resources.Load("Prefabs/" + BasePrefab) as GameObject;
        }

        public void setCurrentBuilding(BuildingInterface building)
        {
            CurrentBuilding = building;
            CurrentBuilding.CurrentLvl = 1;
        }
        
        public bool isEmptyCell()
        {
            return CurrentBuilding is None;
        }
        
        public List<BuildingInterface> getAllowedBuilds()
        {
            return AllowedBuildings;
        }
    }
}
