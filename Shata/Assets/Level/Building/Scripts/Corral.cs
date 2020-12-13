using System.Collections.Generic;
using Level.Cell;

namespace Level.Building
{
    public abstract class Corral : Building
    {
        public override string Description => "Generate food from sheep.";
        public override string Comment => "This building does not generate as much food as the farm, but does not need a particular cell. Additionally allow you to give your citizens a complete diet.";
        public override string Title => "Corral";
        public override string BasePrefab => "Corral";

        public override List<CellTypeInterface> BuildableIn
            => new List<CellTypeInterface>
            {
                new Grass(),
                new Fertile(),
            };
    }
}
