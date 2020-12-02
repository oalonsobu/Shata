using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class FisherHouse: BuildingInterface
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(80, ResourceType.Wood, ResourceModifierType.Amount)
            };
        
        public override string Description => "Allows you to get food from the water.";
        public override string Comment => "This building does not generate as much food as the farm, but is easier to locate.";
        public override string Title => "FisherHouse";
        public override string BasePrefab => "FisherHouse";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.32f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
    }
}
