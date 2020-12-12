using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class HighMountain : CellTypeInterface
    {
        private List<Building.Building> allowedBuildings;
        
        public override string Description => "Like a mountain. But bigger.";
        public override string Comment => "If you think that a mountain was useless I have bad news for you.";
        public override string Title => "High Mountain";
        public override string BasePrefab => "HighMountainCell";
        
        public override List<Building.Building> AllowedBuildings => allowedBuildings;


        //TODO: can I add a way to make the building expensive or something like that?
        public HighMountain()
        {
            allowedBuildings = new List<Building.Building>();
            allowedBuildings.AddRange(new List<Building.Building>
            {
            });
        }
    }
}
