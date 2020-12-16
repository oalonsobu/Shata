using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Houselvl2 : House
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Houselvl3()
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(60, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(20, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(5, ResourceType.Stone, ResourceModifierType.Amount),
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(5, ResourceType.Population, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.04f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 2;
    }
}
