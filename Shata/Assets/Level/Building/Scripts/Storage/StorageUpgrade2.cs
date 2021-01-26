using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class StorageUpgrade2 : Upgrade
    {
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(130, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(45, ResourceType.Gold, ResourceModifierType.Amount),
            };
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(350, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(350, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(350, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(350, ResourceType.Stone, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.021f, ResourceType.Gold, ResourceModifierType.Production),
            };

        public override List<Upgrade> Upgrades 
            => new List<Upgrade>
            {
                new StorageUpgrade3()
            };
    }
}
