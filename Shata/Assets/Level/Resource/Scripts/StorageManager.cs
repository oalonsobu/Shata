using System;
using System.Collections.Generic;

namespace Level.Resource
{
    public class StorageManager
    {
        public readonly Resource Gold;
        public readonly Resource Wood;
        public readonly Resource Meat;
        public readonly Resource Population;

        public StorageManager()
        {
            Gold = new Resource(ResourceType.Gold);
            Wood = new Resource(ResourceType.Wood);
            Meat = new Resource(ResourceType.Meat);
            Population = new Resource(ResourceType.Population);

            AddModifier(new List<ResourceModifier>{
                new FlatPerkModifier(1, ResourceType.Gold, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(50f, ResourceType.Gold, ResourceModifierType.Amount),
                new FlatPerkModifier(0f, ResourceType.Wood, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(50f, ResourceType.Wood, ResourceModifierType.Amount),
                new FlatPerkModifier(0.5f, ResourceType.Meat, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(50f, ResourceType.Meat, ResourceModifierType.Amount),
                new FlatPerkModifier(0f, ResourceType.Population, ResourceModifierType.Production),
                new FlatPerkModifier(50f, ResourceType.Population, ResourceModifierType.Storage),
                new FlatPerkModifier(5f, ResourceType.Population, ResourceModifierType.Amount)
            });
        }
        
        public void Update(float time)
        {
            Gold.Update(time);
            Wood.Update(time);
            Meat.Update(time);
            Population.Update(time);
        }
        
        public void AddModifier(IEnumerable<ResourceModifier> resourceModifiers)
        {
            foreach (ResourceModifier resourceModifier in resourceModifiers)
            {
                AddModifier(resourceModifier);
            }
        }

        public bool hasEnoughResources(IEnumerable<ResourceModifier> prices)
        {
            var totalGold = 0.0f;
            var totalMeat = 0.0f;
            var totalWood = 0.0f;
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
                   && totalPopulation <= Population.Amount;
        }

        private void AddModifier(ResourceModifier resourceModifier)
        {
            Resource resource = getResourceByType(resourceModifier.ResourceType);
            resource.AddModifier(resourceModifier);
            resource.ApplyModifiers();
        }

        private Resource getResourceByType(ResourceType resourceType)
        {
            //TODO: get resource or something like that
            switch (resourceType)
            {
                case ResourceType.Gold:
                    return Gold;
                case ResourceType.Wood:
                    return Wood;
                case ResourceType.Meat:
                    return Meat;
                case ResourceType.Population:
                    return Population;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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