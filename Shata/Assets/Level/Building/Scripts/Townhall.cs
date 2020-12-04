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
        
        public override string Description => "Main building of your village.";
        public override string Comment => "Is the first building of your village, and only one can bu built. The town hall have room for a few citizens and resource and when built, you're gifted with some resources.";
        public override string Title => "Townhall";
        public override string BasePrefab => "Townhall";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                //Initial resources, production and storage
                new FlatPerkModifier(2f, ResourceType.Population, ResourceModifierType.Amount),
                new FlatPerkModifier(200f, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatPerkModifier(50f, ResourceType.Meat, ResourceModifierType.Amount),
                new FlatPerkModifier(50f, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatPerkModifier(0f, ResourceType.Stone, ResourceModifierType.Amount),
                
                
                new FlatPerkModifier(0.05f, ResourceType.Population, ResourceModifierType.Production),
                new FlatPerkModifier(0f, ResourceType.Wood, ResourceModifierType.Production),
                new FlatPerkModifier(0f, ResourceType.Meat, ResourceModifierType.Production),                
                new FlatPerkModifier(0.05f, ResourceType.Gold, ResourceModifierType.Production),
                new FlatPerkModifier(0f, ResourceType.Stone, ResourceModifierType.Production),
                
                
                new FlatPerkModifier(6f, ResourceType.Population, ResourceModifierType.Storage),
                new FlatPerkModifier(500f, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(500f, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(500f, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(500f, ResourceType.Stone, ResourceModifierType.Storage),
            };
    }
}
