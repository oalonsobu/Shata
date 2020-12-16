using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Farmlvl3 : Farm
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(160, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(75, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatHandicapModifier(25, ResourceType.Stone, ResourceModifierType.Amount),
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.95f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.09f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 3;
    }
}
