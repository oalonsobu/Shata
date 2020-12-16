using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Houselvl1 : House
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Houselvl2()
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(50, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(10, ResourceType.Gold, ResourceModifierType.Amount)
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(3, ResourceType.Population, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.02f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 1;
    }
}
