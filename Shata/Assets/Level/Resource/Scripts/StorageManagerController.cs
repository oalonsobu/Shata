using System;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace Level.Resource
{
    public class StorageManagerController : MonoBehaviour
    {
        [SerializeField] StorageReference storageReference;
        
        void Awake()
        {
            storageReference.value = new StorageManager();
        }
        
        void Update()
        {
            storageReference.value.Update(Time.deltaTime);
        }
    }
}