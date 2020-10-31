using System.Collections.Generic;

namespace Level.Grid
{
    public class Farm : CellTypeInterface
    {
        public override string Description => "Ideal for farming.";
        public override string Comment => "You can build anything here, but I recommend you to build farms. You will not have many of this";
        public override string Title => "Fertile land";
        public override string BasePrefab => "FarmCell";
        
        public override List<BuildingInterface> AllowedBuildings => new List<BuildingInterface>();
    }
}
