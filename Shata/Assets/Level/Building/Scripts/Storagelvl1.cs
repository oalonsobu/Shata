using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Storagelvl1 : Storage
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Storagelvl2()
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(60, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(30, ResourceType.Gold, ResourceModifierType.Amount),
            };
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(200, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(200, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(200, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(200, ResourceType.Stone, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.01f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 1;
    }
}
