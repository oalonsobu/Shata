using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class HouseUpgrade3 : Upgrade
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(75, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(25, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(15, ResourceType.Stone, ResourceModifierType.Amount),
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(7, ResourceType.Population, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.06f, ResourceType.Gold, ResourceModifierType.Production),
            };

        public override List<Upgrade> Upgrades
            => new List<Upgrade>
            {
            };
    }
}
