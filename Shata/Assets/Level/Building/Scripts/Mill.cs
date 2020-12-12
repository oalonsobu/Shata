using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public abstract class Mill : Building
    {
        public override string Description => "Increases your meat production and storage.";
        public override string Comment => "In the mill you can store here you food";
        public override string Title => "Mill";
        public override string BasePrefab => "Mill";
    }
}
