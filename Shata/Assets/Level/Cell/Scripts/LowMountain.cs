using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class LowMountain : CellTypeInterface
    {
        private List<BuildingInterface> allowedBuildings;
        
        public override string Description => "Like a mountain. But smaller.";
        public override string Comment => "Maybe you though you would be able to build something here, but you can't. Sorry not sorry.";
        public override string Title => "Low mountain";
        public override string BasePrefab => "LowMountainCell";
        
        public override List<BuildingInterface> AllowedBuildings => allowedBuildings;


        public LowMountain()
        {
            allowedBuildings = new List<BuildingInterface>();
            allowedBuildings.AddRange(new List<BuildingInterface>
            {
            });
        }
    }
}
