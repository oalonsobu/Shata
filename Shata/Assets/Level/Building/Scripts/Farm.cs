using System.Collections.Generic;
using Level.Cell;

namespace Level.Building
{
    public abstract class Farm : Building
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
        
        protected override bool assertConditions(CellBase cell)
        {
            return true;
        }
    }
}
