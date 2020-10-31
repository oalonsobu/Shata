using System.Collections.Generic;

namespace Level.Grid
{
    public class Farm : CellTypeInterface
    {
        private List<BuildingInterface> allowedBuildings;
        
        public override string Description => "Ideal for farming.";
        public override string Comment => "You can build anything here, but I recommend you to build farms. You will not have many of this";
        public override string Title => "Fertile land";
        public override string BasePrefab => "FarmCell";
        
        public override List<BuildingInterface> AllowedBuildings => allowedBuildings;


        public Farm()
        {
            allowedBuildings = new List<BuildingInterface>();
            allowedBuildings.Add(new House());
        }
    }
}
