using UnityEngine;

namespace Level.Grid
{
    public class Grass : CellTypeInterface
    {
        private const string BasePrefab = "GrassCell";
        private const string Description = "Ideal for ranching or random buildings";
        private const string Comment = "Plenty of flowers, herbs and grass. Pettry but useless if you don't build something here.";
        private const string Title = "Grassland";
        
        public void getAllowedBuildings() {
            throw new System.NotImplementedException();
        }
        
        public GameObject getBasePrefab()
        {
            return Resources.Load("Prefabs/" + BasePrefab) as GameObject;
        }

        public string getDesription() {
            return Description;
        }

        public string getComment()
        {
            return Comment;
        }

        public string getTitle()
        {
            return Title;
        }
    }
}
