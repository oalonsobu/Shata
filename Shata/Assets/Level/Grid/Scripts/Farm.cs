using UnityEngine;

namespace Level.Grid
{
    public class Farm : CellTypeInterface
    {
        private const string BasePrefab = "FarmCell";
        private const string Description = "Ideal for farming.";
        private const string Comment = "You can build anything here, but I recommend to build farms. You will not have many of this";
        private const string Title = "Fertile land";
        
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
