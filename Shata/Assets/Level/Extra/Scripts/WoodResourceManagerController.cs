using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class WoodResourceManagerController : ResourceManagerController
    {
        void Start()
        {
            resourceReference.resource = new Resource(0, 500, new FlatPerkModifier(0f));
        }
    }
}
