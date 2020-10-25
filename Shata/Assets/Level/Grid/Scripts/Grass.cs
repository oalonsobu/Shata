using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Grid
{
    public class Grass : TypeInterface
    {
        
        private const string Description = "Ideal for ranching or farming.";
        private const string Comment = "Plenty of flowers, herbs and grass. Pettry but useless if you don't build something here.";
        private const string Title = "Grassland";
        
        public void getAllowedBuildings() {
            throw new System.NotImplementedException();
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
