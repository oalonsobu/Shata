using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Farmlvl2 : Farm
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Farmlvl3()
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(110, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(50, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(10, ResourceType.Stone, ResourceModifierType.Amount),
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.75f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.061f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 2;
    }
}
