using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class GoldResourceManagerController : ResourceManagerController
    {
        void Start()
        {
            resourceReference.resource = new Resource(0, new FlatPerkModifier(500f), new FlatPerkModifier(0.5f));
        }
    }
}
