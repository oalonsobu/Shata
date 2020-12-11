using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Mine : BuildingInterface
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(50, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(10, ResourceType.Gold, ResourceModifierType.Amount),
                
            };
        
        public override string Description => "Extract stone form mountains";
        public override string Comment => "Stone is primary used in advanced constructions. The buildings that use stone are more durable than the ones that only use wood. Additionally, it helps to keep the houses warmer.";
        public override string Title => "Mine";
        public override string BasePrefab => "Mine";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.12f, ResourceType.Stone, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
    }
}
