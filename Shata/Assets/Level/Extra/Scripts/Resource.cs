using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Level.Extra
{
    //TODO: need this to be and abstract class?
    public class Resource
    {
        public float Amount { get; set; }

        public float Max { get;}

        //Todo: if we do an ID we can remove the base modifier, but this works for now
        private FlatPerkModifier BaseModifier { get; }
        private List<ResourceModifier> Modifiers { get; }
        private ResourceModifier BaseMaxModifier { get; }
        private List<ResourceModifier> MaxModifiers { get; }
        

        public Resource(float amount, FlatPerkModifier baseMaxModifier, FlatPerkModifier baseModifier)
        {
            Amount = amount;
            BaseMaxModifier = baseMaxModifier;
            BaseModifier = baseModifier;
            Modifiers = new List<ResourceModifier>();
            MaxModifiers = new List<ResourceModifier>();
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
        public void RemoveModifier(ResourceModifier resourceModifier)
        {
            Modifiers.Remove(resourceModifier);
        }
        
        public float ApplyMaxModifier()
        {
            var total = BaseMaxModifier.Amount;
            foreach (ResourceModifier resourceModifier in MaxModifiers)
            {
                total += resourceModifier;
            }

            return total;
        }

        public void AddMaxModifier(ResourceModifier resourceModifier)
        {
            MaxModifiers.Add(resourceModifier);
        }
        
        //TODO: this not gonna work
        public void RemoveMaxModifier(ResourceModifier resourceModifier)
        {
            MaxModifiers.Remove(resourceModifier);
        }
    }
}
