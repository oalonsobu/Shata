using UnityEngine;
using Variables;

namespace Level.Resource
{
    public class FlatPerkModifier : ResourceModifier
    {
        public FlatPerkModifier(float amount, ResourceType resourceType, ResourceModifierType resourceModifierType) : base(amount, resourceType, resourceModifierType){}


        protected override float Apply(float a)
        {
            return a + Amount;
        }
    }
}
