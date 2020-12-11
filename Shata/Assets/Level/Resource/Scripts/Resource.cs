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

        private Dictionary<int, List<ResourceModifier>> Modifiers { get; }
        
        public Resource(ResourceType resourceType)
        {
            ResourceType = resourceType;
            Modifiers = new Dictionary<int, List<ResourceModifier>>();
            Storage = 0;
            Production = 0;
            Amount = 0;
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
        
        public void ApplyModifiers()
        {
            Production = 0.0f;
            Storage = 0.0f;
            foreach (KeyValuePair<int,List<ResourceModifier>> resourceModifiers in Modifiers)
            {
                foreach (ResourceModifier resourceModifier in resourceModifiers.Value)
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
        }

        public void AddModifier(int id, ResourceModifier resourceModifier)
        {
            if (resourceModifier.ResourceModifierType == ResourceModifierType.Amount)
            {
                Amount += resourceModifier;
            }
            else
            {
                if (!Modifiers.ContainsKey(id))
                {
                    Modifiers.Add(id, new List<ResourceModifier>());
                }
                
                Modifiers[id].Add(resourceModifier);
            }
        }
        
        public void RemoveModifier(int id, ResourceModifier resourceModifier)
        {
            if (Modifiers.ContainsKey(id))
            {
                Modifiers.Remove(id);
            }
        }
    }
}
