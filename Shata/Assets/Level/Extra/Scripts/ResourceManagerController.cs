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
            if (resourceReference.resource.Amount < resourceReference.resource.Max && resourceReference.resource.Amount >= 0)
            {
                float increment = resourceReference.resource.ApplyModifier();
                resourceReference.resource.Amount += increment * Time.deltaTime;
            } else if (resourceReference.resource.Amount < 0)
            {
                resourceReference.resource.Amount = 0;
            }
        }
    }
}
