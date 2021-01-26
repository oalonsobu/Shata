using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public class Storage : Building
    {
        public override string Description => "Storage all kind of resources here.";
        public override string Comment => "You can put everything you want here. Not recommended to live here, even a single night can be fatal.";
        public override string Title => "Storage";
        public override string BasePrefab => "Storage";
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Grass(),
                new Fertile(),
            };

        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(60, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatHandicapModifier(30, ResourceType.Gold, ResourceModifierType.Amount),
            };
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(200, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(200, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(200, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(200, ResourceType.Stone, ResourceModifierType.Storage),
                
                //Upkeep
                new FlatHandicapModifier(0.01f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override List<Upgrade> Upgrades 
            => new List<Upgrade>
            {
                new StorageUpgrade2()
            };
    }
}
