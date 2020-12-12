using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Stone : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;
        
        public override string Description => "There is a lot of stone here.";
        public override string Comment => "Do we have a resource named stone? If so, maybe you can build something here to get that.";
        public override string Title => "Stone";
        public override string BasePrefab => "StoneCell";
        
        public override List<Building.Building> AllowedBuildings => allowedBuildings;


        //TODO: can I add a way to make the building expensive or something like that?
        public Stone()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
                new Minelvl1()
            });
        }
    }
}
