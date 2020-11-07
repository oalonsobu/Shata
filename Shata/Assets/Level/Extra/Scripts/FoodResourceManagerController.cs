using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class FoodResourceManagerController : ResourceManagerController
    {
        void Start()
        {
            resourceReference.resource = new Resource(0, new FlatPerkModifier(500f), new FlatPerkModifier(1));
        }
    }
}
