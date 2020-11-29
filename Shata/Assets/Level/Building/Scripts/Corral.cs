using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Corral : BuildingInterface
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(60, ResourceType.Wood, ResourceModifierType.Amount)
                
            };
        
        public override string Description => "Generate food from sheep.";
        public override string Comment => "This building does not generate as much food as the farm, but does not need a particular cell. Additionally allow you to give your citizens a complete diet";
        public override string Title => "Corral";
        public override string BasePrefab => "Corral";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.21f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
    }
}
