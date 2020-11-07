using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class Resource
    {
        public float Amount { get; set; }

        public float Storage { get; private set; }

        public float Production { get; private set; }

        private List<ResourceModifier> Modifiers { get; }
        
        public Resource(float amount, FlatPerkModifier modifier, FlatPerkModifier maxModifier)
        {
            Storage = 0;
            Production = 0;
            Amount = amount;
            Modifiers = new List<ResourceModifier>();
            Modifiers.Add(modifier);
            Modifiers.Add(maxModifier);
        }
        
        public void Update(float time)
        {
            ApplyModifiers();
            if (Amount < Storage && Amount >= 0)
            {
                Amount += Production * time;
            } else if (Amount < 0)
            {
                Amount = 0;
                Storage = 0;
            }
            
        }
        
        private void ApplyModifiers()
        {
            Production = 0.0f;
            Storage = 0.0f;
            foreach (ResourceModifier resourceModifier in Modifiers)
            {
                switch (resourceModifier.ResourceModifierType)
                {
                    case ResourceModifierType.Production:
                        Production += resourceModifier;
                        break;
                    case ResourceModifierType.Storage:
                        Storage += resourceModifier;
                        break;
                }
            }
        }

        public void AddModifier(ResourceModifier resourceModifier)
        {
            Modifiers.Add(resourceModifier);
        }
        
        public void AddModifier(IEnumerable<ResourceModifier> resourceModifiers)
        {
            Modifiers.AddRange(resourceModifiers);
        }
        
        public void RemoveModifier(ResourceModifier resourceModifier)
        {
            throw new NotImplementedException();
        }
        
        public void RemoveModifier(List<ResourceModifier> resourceModifier)
        {
            throw new NotImplementedException();
        }
    }
}
