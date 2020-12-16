using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Townhalllvl3 : Townhall
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(165, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(30, ResourceType.Stone, ResourceModifierType.Amount),
                new FlatHandicapModifier(75, ResourceType.Gold, ResourceModifierType.Amount),
            };

        //TODO: add old modifiers
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.1f, ResourceType.Population, ResourceModifierType.Production),             
                new FlatPerkModifier(0.09f, ResourceType.Gold, ResourceModifierType.Production),
                
                //Initial resources, production and storage
                new FlatPerkModifier(12f, ResourceType.Population, ResourceModifierType.Storage),
                new FlatPerkModifier(800f, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(800f, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(800f, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(800f, ResourceType.Stone, ResourceModifierType.Storage),
            };
        
        public override int CurrentLvl => 2;
    }
}
