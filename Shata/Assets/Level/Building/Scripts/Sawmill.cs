using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Sawmill : BuildingInterface
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(40, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(10, ResourceType.Gold, ResourceModifierType.Amount)
            };
        
        public override string Description => "Produces wood from trees.";
        public override string Comment => "Cuts down the trees and produces wood. This resource is used for build and level up other buildings.";
        public override string Title => "Sawmill";
        public override string BasePrefab => "Sawmill";
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(2, ResourceType.Wood, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.15f, ResourceType.Gold, ResourceModifierType.Production),
            };
    }
}
