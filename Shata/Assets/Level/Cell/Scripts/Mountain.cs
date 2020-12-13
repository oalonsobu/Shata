namespace Level.Cell
{
    public class Mountain : CellTypeInterface
    {
        public override string Description => "A huge mountain. Nothing can be built here.";
        public override string Comment => "It cannot be crossed. You cannot built here either. You cannot get resources from here. Totally useless cell.";
        public override string Title => "Mountain";
        public override string BasePrefab => "MountainCell";
    }
}
