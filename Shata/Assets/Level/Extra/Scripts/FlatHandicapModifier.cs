using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class FlatHandicapModifier : ResourceModifier
    {
        public FlatHandicapModifier(float a) : base(a) {}
        
        public static float operator+ (float a, FlatHandicapModifier b) {
            return a - b.Amount;
        }
    }
}
