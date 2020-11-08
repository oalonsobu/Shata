using UnityEngine;
using Variables;

namespace Level.Resource
{
    public class FlatHandicapModifier : ResourceModifier
    {
        public FlatHandicapModifier(float amount, ResourceType resourceType, ResourceModifierType resourceModifierType) : base(amount, resourceType, resourceModifierType){}

        protected override float Apply(float a)
        {
            return a - Amount;
        }
    }
}
