using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class None : BuildingInterface
    {
        public override int Price => 0;
        public override string Description => "There is nothing here.";
        public override string Comment => "Do you want to build something here?.";
        public override string Title => "Empty";
        public override string BasePrefab => "None";
                
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
            };
    }
}
