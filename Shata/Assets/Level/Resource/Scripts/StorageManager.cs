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
        
        public void AddModifier(ResourceModifier resourceModifier)
        {
            switch (resourceModifier.ResourceType)
            {
                case ResourceType.Gold:
                    Gold.AddModifier(resourceModifier);
                    Gold.ApplyModifiers();
                    break;
                case ResourceType.Wood:
                    Wood.AddModifier(resourceModifier);
                    Wood.ApplyModifiers();
                    break;
                case ResourceType.Meat:
                    Meat.AddModifier(resourceModifier);
                    Meat.ApplyModifiers();
                    break;
                case ResourceType.Population:
                    Population.AddModifier(resourceModifier);
                    Population.ApplyModifiers();
                    break;
            }
        }
        
        public void AddModifier(IEnumerable<ResourceModifier> resourceModifiers)
        {
            foreach (ResourceModifier resourceModifier in resourceModifiers)
            {
                AddModifier(resourceModifier);
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