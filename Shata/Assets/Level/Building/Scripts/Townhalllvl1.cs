using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Townhalllvl1 : Townhall
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Townhalllvl2()
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
            };

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
                
                
                //Todo: remove, testing
                new FlatPerkModifier(2f, ResourceType.Population, ResourceModifierType.Amount),
                new FlatPerkModifier(500f, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatPerkModifier(500f, ResourceType.Meat, ResourceModifierType.Amount),
                new FlatPerkModifier(500f, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatPerkModifier(500f, ResourceType.Stone, ResourceModifierType.Amount),
            };
        
        public override int CurrentLvl => 1;
    }
}
