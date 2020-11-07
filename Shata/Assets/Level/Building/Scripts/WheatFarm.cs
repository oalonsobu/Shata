using System.Collections.Generic;
using Level.Extra;

namespace Level.Building
{
    public class Farm : BuildingInterface
    {
        //TODO: wood cost
        public override int Price => 10;
        public override string Description => "Gives you meat";
        public override string Comment => "I don't know what to say u fucking bastard";
        public override string Title => "Farm";
        public override string BasePrefab => "House";
        
        public override List<ResourceModifier> GoldModifiers => new List<ResourceModifier>();
        public override List<ResourceModifier> WoodModifiers => new List<ResourceModifier>();
        public override List<ResourceModifier> FoodModifiers => new List<ResourceModifier>{ new FlatPerkModifier(2, ResourceModifierType.Production)};
        public override List<ResourceModifier> PopulationModifiers => new List<ResourceModifier>();
    }
}
