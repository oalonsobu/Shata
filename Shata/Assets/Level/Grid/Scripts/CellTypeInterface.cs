using UnityEngine;
using System.Collections.Generic;

namespace Level.Grid
{

    public abstract class CellTypeInterface
    {
        public abstract string Description { get; }
        public abstract string Comment { get; }
        public abstract string Title { get; }
        public abstract string BasePrefab { get; }
        public abstract List<BuildingInterface> AllowedBuildings { get; }

        private BuildingInterface Building { get; set; }
        
        //TODO: check for errors?
        public GameObject getBasePrefab() {
            return Resources.Load("Prefabs/" + BasePrefab) as GameObject;
        }
    }
}
