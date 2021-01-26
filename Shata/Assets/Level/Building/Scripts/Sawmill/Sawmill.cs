using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public class Sawmill : Building
    {
        public override string Description => "Produces wood from trees.";
        public override string Comment => "Cuts down the trees and produces wood. This resource is used for build and level up other buildings.";
        public override string Title => "Sawmill";
        public override string BasePrefab => "Sawmill";
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Forest(),
            };
        
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(50, ResourceType.Wood, ResourceModifierType.Amount)
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.2f, ResourceType.Wood, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.015f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override List<Upgrade> Upgrades 
            => new List<Upgrade>
            {
            };
        
        protected override bool assertConditions(CellBase cell)
        {
            return true;
        }
    }
}
