using System.Collections.Generic;

namespace Level.Grid
{
    public class None : BuildingInterface
    {
        public override int Price => 0;
        public override string Description => "There is nothing here.";
        public override string Comment => "Do you want to build something here?.";
        public override string Title => "Empty";
        public override string BasePrefab => "None";
    }
}
