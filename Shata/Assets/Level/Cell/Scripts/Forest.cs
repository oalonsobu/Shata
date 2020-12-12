using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Forest : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;
        
        public override string Description => "Wood is the primary resource to build. You can extract it from here.";
        public override string Comment => "Your citizens can extract wood from here.";
        public override string Title => "Fores";
        public override string BasePrefab => "ForestCell";

        public override List<Building.Building> AllowedBuildings => allowedBuildings;

        public Forest()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
                new Sawmilllvl1()
            });
        }
    }
}
