namespace Level.Cell
{
    public class Forest : CellTypeInterface
    { 
        public override string Description => "Wood is the primary resource to build. You can extract it from here.";
        public override string Comment => "Your citizens can extract wood from here.";
        public override string Title => "Fores";
        public override string BasePrefab => "ForestCell";
    }
}
