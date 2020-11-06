using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class GoldResourceManagerController : ResourceManagerController
    {
        void Start()
        {
            resourceReference.resource = new Resource(0, 500, new FlatPerkModifier(0.5f));
        }
    }
}
