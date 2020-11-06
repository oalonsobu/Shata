using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class FlatPerkModifier : ResourceModifier
    {
        public FlatPerkModifier(float a) : base(a) {}
        
        public static float operator+ (float a, FlatPerkModifier b) {
            return a + b.Amount;
        }
    }
}
