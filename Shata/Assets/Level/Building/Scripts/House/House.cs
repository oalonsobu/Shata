using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public class House : Building
    {
        public override string Description => "Increase your max population.";
        public override string Comment => "Here is where you citizens live. Build more if you want to make your beautiful city grow.";
        public override string Title => "House";
        public override string BasePrefab => "House";
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Grass(),
                new Fertile(),
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
        
        public override List<Upgrade> Upgrades  
            => new List<Upgrade>
            {
                new HouseUpgrade2()
            };
    }
}
