using System;
using System.Collections.Generic;

namespace Level.Resource
{
    public class StorageManager
    {
        public Resource Gold;
        public Resource Wood;
        public Resource Meat;
        public Resource Population;

        public StorageManager()
        {
            Gold = new Resource(50, ResourceType.Gold);
            Wood = new Resource(50, ResourceType.Wood);
            Meat = new Resource(50, ResourceType.Meat);
            Population = new Resource(0, ResourceType.Population);

            AddModifier(new List<ResourceModifier>{
                new FlatPerkModifier(1, ResourceType.Gold, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Gold, ResourceModifierType.Storage),
                new FlatPerkModifier(0f, ResourceType.Wood, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Wood, ResourceModifierType.Storage),
                new FlatPerkModifier(0.5f, ResourceType.Meat, ResourceModifierType.Production),
                new FlatPerkModifier(500f, ResourceType.Meat, ResourceModifierType.Storage),
                new FlatPerkModifier(0f, ResourceType.Population, ResourceModifierType.Production),
                new FlatPerkModifier(50f, ResourceType.Population, ResourceModifierType.Storage),
            });
        }
        
        public void AddModifier(ResourceModifier resourceModifier)
        {
            switch (resourceModifier.ResourceType)
            {
                case ResourceType.Gold:
                    Gold.AddModifier(resourceModifier);
                    break;
                case ResourceType.Wood:
                    Wood.AddModifier(resourceModifier);
                    break;
                case ResourceType.Meat:
                    Meat.AddModifier(resourceModifier);
                    break;
                case ResourceType.Population:
                    Population.AddModifier(resourceModifier);
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