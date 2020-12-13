using System.Collections.Generic;
using Level.Cell;

namespace Level.Building
{
    public abstract class Storage : Building
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
    }
}
