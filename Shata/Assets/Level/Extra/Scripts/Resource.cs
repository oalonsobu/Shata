using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Level.Extra
{
    //TODO: need this to be and abstract class?
    public class Resource
    {
        public float Amount { get; set; }

        public float Max { get; set; }

        private FlatPerkModifier BaseModifier { get; }
        private List<ResourceModifier> Modifiers { get; }
        

        public Resource(float amount, float max, FlatPerkModifier baseModifier)
        {
            Amount = amount;
            Max = max;
            BaseModifier = baseModifier;
            Modifiers = new List<ResourceModifier>();
        }
        
        public float ApplyModifier()
        {
            var total = BaseModifier.Amount;
            foreach (ResourceModifier resourceModifier in Modifiers)
            {
                total += resourceModifier;
            }

            return total;
        }

        public void AddModifier(ResourceModifier resourceModifier)
        {
            Modifiers.Add(resourceModifier);
        }
        
        //TODO: this not gonna work
        public void Remove(ResourceModifier resourceModifier)
        {
            Modifiers.Remove(resourceModifier);
        }
    }
}
