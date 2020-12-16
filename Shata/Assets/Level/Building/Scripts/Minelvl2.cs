using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Minelvl2 : Mine
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Minelvl3()
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(100, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(50, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(20, ResourceType.Stone, ResourceModifierType.Amount),
                
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.18f, ResourceType.Stone, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.06f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 2;
    }
}
