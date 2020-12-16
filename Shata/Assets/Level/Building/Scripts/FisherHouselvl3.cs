using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class FisherHouselvl3: FisherHouse
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(200, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(75, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(20, ResourceType.Stone, ResourceModifierType.Amount),
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.56f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.1f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 3;
    }
}
