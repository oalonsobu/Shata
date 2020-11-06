using UnityEngine;
using Variables;

namespace Level.Extra
{
    public abstract class ResourceModifier
    {
        public float Amount { get; }

        protected ResourceModifier(float a)
        {
            Amount = a;
        }
        
        public static float operator+ (float a, ResourceModifier b) {
            return a + b.Amount;
        }
    }
}
