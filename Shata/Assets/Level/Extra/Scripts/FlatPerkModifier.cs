using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class FlatPerkModifier : ResourceModifier
    {
        public FlatPerkModifier(float amount, ResourceModifierType resourceModifierType) : base(amount, resourceModifierType){}


        protected override float Apply(float a)
        {
            return a + Amount;
        }
    }
}
