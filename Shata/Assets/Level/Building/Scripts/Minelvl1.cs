using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Minelvl1 : Mine
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Minelvl2()
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(50, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(10, ResourceType.Gold, ResourceModifierType.Amount),
                
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.12f, ResourceType.Stone, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 1;
    }
}
