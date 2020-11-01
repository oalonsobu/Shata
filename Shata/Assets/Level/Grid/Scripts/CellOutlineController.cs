using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;



//TODO: convertir esto en una clase sin logica, que solo responda a eventos varios y llame a lo que pertoca. Sera el CellReference
namespace Level.Grid
{
    //Cell information related with unity behaviours
    public class CellOutlineController : MonoBehaviour
    {
        Outline outline;
        
        void Start() {
            outline = GetComponent<Outline>();
            outline.enabled = false;
        }
        
        public void enable () {
            outline.enabled = true;
        }
        
        public void disable () {
            outline.enabled = false;
        }
    }
}
