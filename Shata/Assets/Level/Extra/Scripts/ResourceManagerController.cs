using UnityEngine;
using UnityEngine.Serialization;
using Variables;

namespace Level.Extra
{
    //TODO: Create abstract class
    public abstract class ResourceManagerController : MonoBehaviour
    {
        [SerializeField] protected ResourceReference resourceReference;
        
        protected void Update()
        {
            resourceReference.resource.Update(Time.deltaTime);
        }
    }
}
