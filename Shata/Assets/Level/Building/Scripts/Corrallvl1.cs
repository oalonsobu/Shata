﻿using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class Corrallvl1 : Corral
    {
        public override List<Building> UpgradableTo
            => new List<Building>
            {
                new Corrallvl2()
            }; 

        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(60, ResourceType.Wood, ResourceModifierType.Amount)
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.21f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };

        public override int CurrentLvl => 1;
    }
}
