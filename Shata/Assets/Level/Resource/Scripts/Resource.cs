using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Variables;

namespace Level.Resource
{
    public class Resource
    {
        public float Amount { get; set; }
        
        public ResourceType ResourceType { get; set; }

        public float Storage { get; private set; }

        public float Production { get; private set; }

        private List<ResourceModifier> Modifiers { get; }
        
        public Resource(float amount, ResourceType resourceType)
        {
            Amount = amount;
            ResourceType = resourceType;
            Modifiers = new List<ResourceModifier>();
            Storage = 0;
            Production = 0;
        }
        
        public void Update(float time)
        {
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
        
        public void RemoveModifier(ResourceModifier resourceModifier)
        {
            throw new NotImplementedException();
        }
    }
}
