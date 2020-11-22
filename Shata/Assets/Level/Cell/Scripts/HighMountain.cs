using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class HighMountain : CellTypeInterface
    {
        private List<BuildingInterface> allowedBuildings;
        
        public override string Description => "Like a mountain. But bigger.";
        public override string Comment => "If you think that a mountain was useless I have bad news for you.";
        public override string Title => "High Mountain";
        public override string BasePrefab => "HighMountainCell";
        
        public override List<BuildingInterface> AllowedBuildings => allowedBuildings;


        //TODO: can I add a way to make the building expensive or something like that?
        public HighMountain()
        {
            allowedBuildings = new List<BuildingInterface>();
            allowedBuildings.AddRange(new List<BuildingInterface>
            {
            });
        }
    }
}
