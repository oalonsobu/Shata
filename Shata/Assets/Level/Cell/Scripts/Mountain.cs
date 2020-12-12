using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Mountain : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;
        
        public override string Description => "A huge mountain. Nothing can be built here.";
        public override string Comment => "It cannot be crossed. You cannot built here either. You cannot get resources from here. Totally useless cell.";
        public override string Title => "Mountain";
        public override string BasePrefab => "MountainCell";
        
        public override List<Building.Building> AllowedBuildings => allowedBuildings;


        //TODO: can I add a way to make the building expensive or something like that?
        public Mountain()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
            });
        }
    }
}
