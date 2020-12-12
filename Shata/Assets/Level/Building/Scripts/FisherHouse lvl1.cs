﻿using System.Collections.Generic;
using Level.Resource;

namespace Level.Building
{
    public class FisherHouselvl1: FisherHouse
    {
        public override List<ResourceModifier> Price 
            => new List<ResourceModifier>
            {
                new FlatHandicapModifier(80, ResourceType.Wood, ResourceModifierType.Amount)
            };

        public override List<ResourceModifier> Modifiers
            => new List<ResourceModifier>
            {
                new FlatPerkModifier(0.32f, ResourceType.Meat, ResourceModifierType.Production),
                
                //Upkeep
                new FlatHandicapModifier(0.03f, ResourceType.Gold, ResourceModifierType.Production),
            };
        
        public override int CurrentLvl => 1;
    }
}
