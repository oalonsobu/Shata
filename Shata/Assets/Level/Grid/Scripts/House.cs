using System.Collections.Generic;

namespace Level.Grid
{
    public class House : BuildingInterface
    {
        //TODO: wood cost
        public override int Price => 50;
        public override string Description => "Increase your max population.";
        public override string Comment => "Here is where you citizens live. Build more if you want to make your beautiful city grow.";
        public override string Title => "House";
        public override string BasePrefab => "House";
    }
}
