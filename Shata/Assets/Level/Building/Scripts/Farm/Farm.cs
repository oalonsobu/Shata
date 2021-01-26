using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public class Farm : Building
    {
        public override string Description => "Gives you food";
        public override string Comment => "I don't know what to say about this, is just a farm...";
        public override string Title => "Farm";
        public override string BasePrefab => "Farm";
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Fertile(),
            };

        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(80, ResourceType.Wood, ResourceModifierType.Amount)
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.5f, ResourceType.Meat, ResourceModifierType.Production),

                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override List<Upgrade> Upgrades  
            => new List<Upgrade>
            {
                new FarmUpgrade2()
            };

        protected override bool assertConditions(CellBase cell)
        {
            return true;
        }
    }
}
