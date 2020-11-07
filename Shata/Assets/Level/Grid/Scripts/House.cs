using System.Collections.Generic;
using Level.Extra;

namespace Level.Grid
{
    public class House : BuildingInterface
    {
        //TODO: wood cost
        public override int Price => 50;
        public override string Description => "Increase your max population.";
        public override string Comment => "Here is where you citizens live. Build more if you want to make your beautiful city grow.";
        public override string Title => "House";
        public override string BasePrefab => "House";
        
        public override List<ResourceModifier> GoldModifiers => new List<ResourceModifier> {new FlatPerkModifier(1, ResourceModifierType.Production)};
        public override List<ResourceModifier> WoodModifiers => new List<ResourceModifier>();
        public override List<ResourceModifier> FoodModifiers => new List<ResourceModifier>();
        public override List<ResourceModifier> PopulationModifiers => new List<ResourceModifier> {new FlatPerkModifier(10, ResourceModifierType.Storage)};
    }
}
