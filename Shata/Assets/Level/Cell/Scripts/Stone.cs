namespace Level.Cell
{
    public class Stone : CellTypeInterface
    {
        public override string Description => "There is a lot of stone here.";
        public override string Comment => "Do we have a resource named stone? If so, maybe you can build something here to get that.";
        public override string Title => "Stone";
        public override string BasePrefab => "StoneCell";
    }
}
