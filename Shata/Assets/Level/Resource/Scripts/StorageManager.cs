using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Resource
{
    public class StorageManager
    {
        public readonly Resource Gold;
        public readonly Resource Wood;
        public readonly Resource Meat;
        public readonly Resource Stone;
        public readonly Resource Population;

        public StorageManager()
        {
            Gold = new Resource(ResourceType.Gold);
            Wood = new Resource(ResourceType.Wood);
            Meat = new Resource(ResourceType.Meat);
            Stone = new Resource(ResourceType.Stone);
            Population = new Resource(ResourceType.Population);
        }
        
        public void Update(float time)
        {
            Gold.Update(time);
            Wood.Update(time);
            Meat.Update(time);
            Stone.Update(time);
            
            //TODO: do this in a prettier way. It works but...
            int popPreUpdate = (int) Math.Floor(Population.Amount);
            Population.Update(time);
            int popPostUpdate = (int) Math.Floor(Population.Amount);
            if (popPreUpdate != popPostUpdate)
            {
                AddModifier(0, new List<ResourceModifier>
                {
                    new FlatPerkModifier(0.02f, ResourceType.Gold, ResourceModifierType.Production),
                    new FlatHandicapModifier(0.01f, ResourceType.Meat, ResourceModifierType.Production)
                });
            }
        }

        public bool hasEnoughResources(IEnumerable<ResourceModifier> prices)
        {
            var totalGold = 0.0f;
            var totalMeat = 0.0f;
            var totalWood = 0.0f;
            var totalStone = 0.0f;
            var totalPopulation = 0.0f;
            foreach (ResourceModifier price in prices)
            {
                if (price.ResourceModifierType == ResourceModifierType.Amount)
                {
                    switch (price.ResourceType)
                    {
                        case ResourceType.Gold:
                            totalGold += price.Amount;
                            break;
                        case ResourceType.Wood:
                            totalWood += price.Amount;
                            break;
                        case ResourceType.Meat:
                            totalMeat += price.Amount;
                            break;
                        case ResourceType.Stone:
                            totalStone += price.Amount;
                            break;
                        case ResourceType.Population:
                            totalPopulation += price.Amount;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return    totalGold <= Gold.Amount
                   && totalMeat <= Meat.Amount
                   && totalWood <= Wood.Amount
                   && totalStone <= Stone.Amount
                   && totalPopulation <= Population.Amount;
        }

        public void AddModifier(int id, IEnumerable<ResourceModifier> resourceModifiers)
        {
            foreach (ResourceModifier resourceModifier in resourceModifiers)
            {
                AddModifier(id, resourceModifier);
            }
        }
        
        private void AddModifier(int id, ResourceModifier resourceModifier)
        {
            Resource resource = getResourceByType(resourceModifier.ResourceType);
            resource.AddModifier(id, resourceModifier);
            resource.ApplyModifiers();
        }
        
        public void RemoveModifier(int id, IEnumerable<ResourceModifier> resourceModifiers)
        {
            foreach (ResourceModifier resourceModifier in resourceModifiers)
            {
                RemoveModifier(id, resourceModifier);
            }
        }
        
        public void RemoveModifier(int id, ResourceModifier resourceModifier)
        {
            Resource resource = getResourceByType(resourceModifier.ResourceType);
            resource.RemoveModifier(id, resourceModifier);
            resource.ApplyModifiers();
        }
        
        private Resource getResourceByType(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.Gold:
                    return Gold;
                case ResourceType.Wood:
                    return Wood;
                case ResourceType.Meat:
                    return Meat;
                case ResourceType.Stone:
                    return Stone;
                case ResourceType.Population:
                    return Population;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}