using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class House : BuildingInterface
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(40, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(8, ResourceType.Gold, ResourceModifierType.Amount)
            };
        public override string Description => "Increase your max population.";
        public override string Comment => "Here is where you citizens live. Build more if you want to make your beautiful city grow.";
        public override string Title => "House";
        public override string BasePrefab => "House";

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(1, ResourceType.Gold, ResourceModifierType.Production),
                new FlatPerkModifier(4, ResourceType.Population, ResourceModifierType.Storage)
            };
    }
}
