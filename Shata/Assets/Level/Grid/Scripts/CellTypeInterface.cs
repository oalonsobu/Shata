using UnityEngine;

namespace Level.Grid
{

    public abstract class CellTypeInterface
    {
        public abstract string Description { get; }
        public abstract string Comment { get; }
        public abstract string Title { get; }
        public abstract string BasePrefab { get; }
        protected abstract void getAllowedBuildings();
        
        //TODO: check for errors?
        public GameObject getBasePrefab() {
            return Resources.Load("Prefabs/" + BasePrefab) as GameObject;
        }
    }
}
