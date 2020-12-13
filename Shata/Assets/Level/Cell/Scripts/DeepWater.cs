using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class DeepWater : CellTypeInterface
    {
        public override string Description => "Large body of deep water.";
        public override string Comment => "Do not drink.";
        public override string Title => "Deep Water";
        public override string BasePrefab => "DeepWaterCell";
    }
}
