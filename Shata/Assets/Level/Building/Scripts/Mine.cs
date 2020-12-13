using System.Collections.Generic;
using Level.Cell;

namespace Level.Building
{
    public abstract class Mine : Building
    {
        public override string Description => "Extract stone form mountains";
        public override string Comment => "Stone is primary used in advanced constructions. The buildings that use stone are more durable than the ones that only use wood. Additionally, it helps to keep the houses warmer.";
        public override string Title => "Mine";
        public override string BasePrefab => "Mine";
        
        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Stone()
            };
    }
}
