using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Minelvl3 : Mine
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(150, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(70, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(40, ResourceType.Stone, ResourceModifierType.Amount),
                
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.24f, ResourceType.Stone, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.09f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 3;
    }
}
