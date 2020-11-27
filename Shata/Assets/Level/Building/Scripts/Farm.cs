using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Farm : BuildingInterface
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(80, ResourceType.Wood, ResourceModifierType.Amount)
            };
        
        public override string Description => "Gives you meat";
        public override string Comment => "I don't know what to say u fucking bastard";
        public override string Title => "Farm";
        public override string BasePrefab => "Farm";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.5f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
    }
}
