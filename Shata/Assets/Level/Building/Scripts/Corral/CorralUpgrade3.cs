using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class CorralUpgrade3 : Upgrade
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(140, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(75, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(20, ResourceType.Stone, ResourceModifierType.Amount),
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.41f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.1f, ResourceType.Gold, ResourceModifierType.Production),
            };

        public override List<Upgrade> Upgrades 
            => new List<Upgrade>
            {
            };
        
    }
}
