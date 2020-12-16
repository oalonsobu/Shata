using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Storagelvl3 : Storage
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(180, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(60, ResourceType.Gold, ResourceModifierType.Amount),
            };
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(500, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(500, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(500, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(500, ResourceType.Stone, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.031f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 3;
    }
}
