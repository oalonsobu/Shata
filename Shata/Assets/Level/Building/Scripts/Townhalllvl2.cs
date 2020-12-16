using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Townhalllvl2 : Townhall
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(100, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(10, ResourceType.Stone, ResourceModifierType.Amount),
                new FlatHandicapModifier(50, ResourceType.Gold, ResourceModifierType.Amount),
            };

        //TODO: add old modifiers
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.08f, ResourceType.Population, ResourceModifierType.Production),             
                new FlatPerkModifier(0.07f, ResourceType.Gold, ResourceModifierType.Production),
                
                //Initial resources, production and storage
                new FlatPerkModifier(9f, ResourceType.Population, ResourceModifierType.Storage),
                new FlatPerkModifier(650f, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(650f, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(650f, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(650f, ResourceType.Stone, ResourceModifierType.Storage),
            };
        
        public override int CurrentLvl => 2;
    }
}
