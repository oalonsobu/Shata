using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Farm : BuildingInterface
    {
        //TODO: wood cost
        public override int Price => 10;
        public override string Description => "Gives you meat";
        public override string Comment => "I don't know what to say u fucking bastard";
        public override string Title => "Farm";
        public override string BasePrefab => "House";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(2, ResourceType.Gold, ResourceModifierType.Production),
            };
    }
}
