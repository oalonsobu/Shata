using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Grass : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;
        
        public override string Description => "Ideal for ranching or random buildings.";
        public override string Comment => "Plenty of flowers, herbs and grass. Pretty but useless if you don't build something here.";
        public override string Title => "Grassland";
        public override string BasePrefab => "GrassCell";

        public override List<Building.Building> AllowedBuildings => allowedBuildings;

        public Grass()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
                new Houselvl1(),
                new Milllvl1(),
                new Storagelvl1(),
                new Townhalllvl1(),
                new Corrallvl1(),
            });
        }
    }
}
