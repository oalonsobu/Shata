using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public class FisherHouse: Building
    {
        public override string Description => "Allows you to get food from the water.";
        public override string Comment => "This building does not generate as much food as the farm, but is easier to locate.";
        public override string Title => "FisherHouse";
        public override string BasePrefab => "FisherHouse";
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Water()
            };

        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(80, ResourceType.Wood, ResourceModifierType.Amount)
            };
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.32f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override List<Upgrade> Upgrades  
            => new List<Upgrade>
            {
                new FisherHouseUpgrade2()
            };

        protected override bool assertConditions(CellBase cell)
        {
            return !closeToOtherBuilding<FisherHouse>(cell) && closeToOtherCell<Grass>(cell);
        }
    }
}
