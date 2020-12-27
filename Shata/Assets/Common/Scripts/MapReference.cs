using UnityEngine;
using Grid = Level.Grid.Grid;

namespace Variables
{
    [CreateAssetMenu]
    public class MapReference : ScriptableObject
    {
        public Grid value;
    }
    
}
