﻿using System.Collections.Generic;
using Level.Building;

namespace Level.Cell
{
    public class Fertile : CellTypeInterface
    {
        private List<BuildingInterface> allowedBuildings;
        
        public override string Description => "Ideal for farming.";
        public override string Comment => "You can build anything here, but I recommend you to build farms. You will not have many of this";
        public override string Title => "Fertile land";
        public override string BasePrefab => "FertileCell";
        
        public override List<BuildingInterface> AllowedBuildings => allowedBuildings;


        public Fertile()
        {
            allowedBuildings = new List<BuildingInterface>();
            allowedBuildings.AddRange(new List<BuildingInterface>
            {
                new House(),
                new Farm(),
            });
        }
    }
}