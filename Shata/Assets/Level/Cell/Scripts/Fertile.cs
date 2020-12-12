using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Fertile : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;
        
        public override string Description => "Ideal for farming.";
        public override string Comment => "You can build anything here, but I recommend you to build farms. You will not have many of this";
        public override string Title => "Fertile land";
        public override string BasePrefab => "FertileCell";
        
        public override List<Building.Building> AllowedBuildings => allowedBuildings;


        public Fertile()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
                new Farmlvl1(),
            });
        }
    }
}
