using UnityEngine;
using Variables;

namespace Level.Resource
{
    public abstract class ResourceModifier
    {

        public float Amount { get; }
        public ResourceModifierType ResourceModifierType { get; }
        public ResourceType ResourceType { get; }

        protected ResourceModifier(float amount, ResourceType resourceType, ResourceModifierType resourceModifierType)
        {
            Amount = amount;
            ResourceType = resourceType;
            ResourceModifierType = resourceModifierType;
        }
        
        protected abstract float Apply(float a);

        public static float operator+ (float a, ResourceModifier b) {
            return b.Apply(a);
        }
    }
}
