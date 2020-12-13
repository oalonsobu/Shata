using System.Collections.Generic;
using Level.Cell;

namespace Level.Building
{
    public abstract class House : Building
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
    }
}
