using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Water : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;

        public override string Description => "Large body of water.";
        public override string Comment => "Do not drink.";
        public override string Title => "Water";
        public override string BasePrefab => "WaterCell";

        public override List<Building.Building> AllowedBuildings => allowedBuildings;
        
        
        //TODO: can I add a way to make the building expensive or something like that?
        public Water()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
                new FisherHouselvl1()
            });
        }
    }
}
