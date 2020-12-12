using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class LowMountain : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;
        
        public override string Description => "Like a mountain. But smaller.";
        public override string Comment => "Maybe you though you would be able to build something here, but you can't. Sorry not sorry.";
        public override string Title => "Low mountain";
        public override string BasePrefab => "LowMountainCell";
        
        public override List<Building.Building> AllowedBuildings => allowedBuildings;


        public LowMountain()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
            });
        }
    }
}
