namespace Level.Cell
{
    public class Grass : CellTypeInterface
    {
        public override string Description => "Ideal for ranching or random buildings.";
        public override string Comment => "Plenty of flowers, herbs and grass. Pretty but useless if you don't build something here.";
        public override string Title => "Grassland";
        public override string BasePrefab => "GrassCell";
    }
}
