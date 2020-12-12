using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Milllvl1 : Mill
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(110, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(10, ResourceType.Stone, ResourceModifierType.Amount)
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(1, ResourceType.Meat, ResourceModifierType.Production),
                new FlatPerkModifier(150, ResourceType.Meat, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.05f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 1;
    }
}
