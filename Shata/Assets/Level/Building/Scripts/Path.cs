using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public class Path : Building
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(10, ResourceType.Wood, ResourceModifierType.Amount)
                
            };
        
        public override string Description => "Communicate your building to your hometown.";
        public override string Comment => "Nobody likes to walk over the mud. Your citizens are no an exception. This \"building\" allow your buildings to be reachable.";
        public override string Title => "Path";
        public override string BasePrefab => "Path";
        
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        //TODO
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
            };
        
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                //Upkeep
                new FlatHandicapModifier(0.001f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 1;
    }
}
