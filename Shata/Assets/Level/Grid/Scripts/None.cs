using System.Collections.Generic;
using Level.Extra;

namespace Level.Grid
{
    public class None : BuildingInterface
    {
        public override int Price => 0;
        public override string Description => "There is nothing here.";
        public override string Comment => "Do you want to build something here?.";
        public override string Title => "Empty";
        public override string BasePrefab => "None";
                
        public override List<ResourceModifier> GoldModifiers => new List<ResourceModifier>();
        public override List<ResourceModifier> WoodModifiers => new List<ResourceModifier>();
        public override List<ResourceModifier> FoodModifiers => new List<ResourceModifier>();
        public override List<ResourceModifier> PopulationModifiers => new List<ResourceModifier>();
    }
}
