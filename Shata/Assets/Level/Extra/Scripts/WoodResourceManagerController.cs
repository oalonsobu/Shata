using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class WoodResourceManagerController : ResourceManagerController
    {
        void Start()
        {
            resourceReference.resource = new Resource(100, new FlatPerkModifier(0f, ResourceModifierType.Production), new FlatPerkModifier(500f, ResourceModifierType.Storage));
        }
    }
}
