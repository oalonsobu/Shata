namespace Level.Cell
{
    public class Fertile : CellTypeInterface
    {   
        public override string Description => "Ideal for farming.";
        public override string Comment => "You can build anything here, but I recommend you to build farms. You will not have many of this";
        public override string Title => "Fertile land";
        public override string BasePrefab => "FertileCell";
    }
}
