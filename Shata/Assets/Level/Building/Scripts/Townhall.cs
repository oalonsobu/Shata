using System.Collections.Generic;
using Level.Cell;

namespace Level.Building
{
    public abstract class Townhall : Building
    {
        public override string Description => "Main building of your village.";
        public override string Comment => "Is the first building of your village, and only one can bu built. The town hall have room for a few citizens and resource and when built, you're gifted with some resources.";
        public override string Title => "Townhall";
        public override string BasePrefab => "Townhall";
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Grass(),
                new Fertile(),
            };
    }
}
