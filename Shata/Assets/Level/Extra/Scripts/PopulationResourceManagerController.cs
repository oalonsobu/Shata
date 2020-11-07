using System;
using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class PopulationResourceManagerController : ResourceManagerController
    {
        private int previousPop = 0;
        
        [SerializeField] protected ResourceReference goldResourceReference;
        [SerializeField] protected ResourceReference foodResourceReference;
        
        void Start()
        {
            resourceReference.resource = new Resource(0, new FlatPerkModifier(0.05f, ResourceModifierType.Production), new FlatPerkModifier(500f, ResourceModifierType.Storage));
        }

        private void Update()
        {
            if (previousPop != Convert.ToInt32(resourceReference.resource.Amount))
            {
                AddModifiers();
            }
            base.Update();
        }

        void AddModifiers()
        {
            previousPop = Convert.ToInt32(resourceReference.resource.Amount);
            goldResourceReference.resource.AddModifier(new FlatPerkModifier(0.1f, ResourceModifierType.Production));
            foodResourceReference.resource.AddModifier(new FlatHandicapModifier(0.1f, ResourceModifierType.Production));
        }
    }
}
