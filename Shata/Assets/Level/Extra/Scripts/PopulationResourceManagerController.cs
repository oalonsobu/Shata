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
            resourceReference.resource = new Resource(0, 500, new FlatPerkModifier(0.05f));
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
            goldResourceReference.resource.AddModifier(new FlatPerkModifier(0.1f));
            goldResourceReference.resource.AddModifier(new FlatHandicapModifier(0.1f));
        }
    }
}
