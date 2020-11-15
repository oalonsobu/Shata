using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Townhall : BuildingInterface
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
            };
        
        public override string Description => "Main building of your village. Is the first building of your village, and only one can bu built.";
        public override string Comment => "The town hall have room for a few citizens and resource and when built, you're gifted with some resources. Is the center of your village and where the important decisions are made. A village without a town hall is not a village.";
        public override string Title => "Townhall";
        public override string BasePrefab => "Townhall";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(1, ResourceType.Gold, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(50f, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatPerkModifier(0f, ResourceType.Wood, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(50f, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatPerkModifier(0.5f, ResourceType.Meat, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(50f, ResourceType.Meat, ResourceModifierType.Amount),
                new FlatPerkModifier(0f, ResourceType.Population, ResourceModifierType.Production),
                new FlatPerkModifier(50f, ResourceType.Population, ResourceModifierType.Storage),
                new FlatPerkModifier(5f, ResourceType.Population, ResourceModifierType.Amount)
            };
    }
}
