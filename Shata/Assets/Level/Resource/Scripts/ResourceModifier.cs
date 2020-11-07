using UnityEngine;
using Variables;

namespace Level.Extra
{
    public abstract class ResourceModifier
    {

        public float Amount { get; }
        public ResourceModifierType ResourceModifierType { get; }

        protected ResourceModifier(float amount, ResourceModifierType resourceModifierType)
        {
            Amount = amount;
            ResourceModifierType = resourceModifierType;
        }
        
        protected abstract float Apply(float a);

        public static float operator+ (float a, ResourceModifier b) {
            return b.Apply(a);
        }
    }
}
