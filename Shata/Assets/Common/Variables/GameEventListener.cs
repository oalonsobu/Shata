using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Variables
{
    
    [CreateAssetMenu]
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;

        public void OnEnable()
        {
            Event.RegisterListener(this);
        }
        
        public void OnDisable()
        {
            Event.UnregisterListener(this);
        }
        
        public void OnEventRaise()
        {
            Response.Invoke();
        }
    }
}
