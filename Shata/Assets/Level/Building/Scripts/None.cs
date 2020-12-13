using System.Collections.Generic;
using Level.Cell;
using Level.Resource;

namespace Level.Building
{
    public class None : Building
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
            };
        
        public override string Description => "There is nothing here.";
        public override string Comment => "Do you want to build something here?.";
        public override string Title => "Empty";
        public override string BasePrefab => "None";
        
        public override List<Building> UpgradableTo
            => new List<Building>
            {
            }; 
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
            };
                
        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
            };

        public override int CurrentLvl => 1;
    }
}
