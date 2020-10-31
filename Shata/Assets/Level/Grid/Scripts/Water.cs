﻿using UnityEngine;

namespace Level.Grid
{
    public class Water : CellTypeInterface
    {
        private const string BasePrefab = "WaterCell";
        private const string Description = "Large body of water.";
        private const string Comment = "Do not drink.";
        private const string Title = "Water";
        
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
