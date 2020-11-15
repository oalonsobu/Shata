using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Water : CellTypeInterface
    {
        public override string Description => "Large body of water.";
        public override string Comment => "Do not drink.";
        public override string Title => "Water";
        public override string BasePrefab => "WaterCell";

        public override List<BuildingInterface> AllowedBuildings => new List<BuildingInterface>();
    }
}
