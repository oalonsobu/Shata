using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Sawmilllvl1 : Sawmill
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(50, ResourceType.Wood, ResourceModifierType.Amount)
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.2f, ResourceType.Wood, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.015f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 1;
    }
}
