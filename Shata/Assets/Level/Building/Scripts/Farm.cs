using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public abstract class Farm : Building
    {
        public override string Description => "Gives you food";
        public override string Comment => "I don't know what to say about this, is just a farm...";
        public override string Title => "Farm";
        public override string BasePrefab => "Farm";
    }
}
