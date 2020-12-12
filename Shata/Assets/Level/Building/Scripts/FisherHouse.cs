using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public abstract class FisherHouse: Building
    {
        public override string Description => "Allows you to get food from the water.";
        public override string Comment => "This building does not generate as much food as the farm, but is easier to locate.";
        public override string Title => "FisherHouse";
        public override string BasePrefab => "FisherHouse";
    }
}
