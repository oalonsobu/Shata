using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class FlatHandicapModifier : ResourceModifier
    {
        public FlatHandicapModifier(float amount, ResourceModifierType resourceModifierType) : base(amount, resourceModifierType){}

        protected override float Apply(float a)
        {
            return a - Amount;
        }
    }
}
