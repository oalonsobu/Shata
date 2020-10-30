using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Level.Extra
{
    public class ResourceManagerController : MonoBehaviour
    {
        [SerializeField] ResourceReference resourceReference;
       
        void Start()
        {
            resourceReference.amount = 0;
            resourceReference.increment = 1;
            
        }
    
        void Update()
        {
            //Roughly increments that value for each second
            resourceReference.amount = resourceReference.amount + resourceReference.increment * Time.deltaTime;
        }
    }
}
