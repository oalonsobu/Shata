using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Grass : CellTypeInterface
    {
        private List<BuildingInterface> allowedBuildings;
        
        public override string Description => "Ideal for ranching or random buildings.";
        public override string Comment => "Plenty of flowers, herbs and grass. Pretty but useless if you don't build something here.";
        public override string Title => "Grassland";
        public override string BasePrefab => "GrassCell";

        public override List<BuildingInterface> AllowedBuildings => allowedBuildings;

        public Grass()
        {
            allowedBuildings = new List<BuildingInterface>();
            allowedBuildings.AddRange(new List<BuildingInterface>
            {
                new House(),
                new Mill(),
                new Storage(),
                new Townhall(),
            });
        }
    }
}
