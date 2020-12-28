using System.Collections.Generic;
using Level.Cell;

namespace Level.Building
{
    public abstract class Sawmill : Building
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
        
        protected override bool assertConditions(CellBase cell)
        {
            return true;
        }
    }
}
