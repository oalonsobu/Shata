using System.Collections.Generic;
using Level.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using Variables;

namespace Level.Grid
{
    public class CustomCellLinkedList<T>
    {
        private readonly LinkedList<T> pendingToVisit = new LinkedList<T>();
        public int Count => pendingToVisit.Count;


        public void queue(T node, int priority)
        {
            if (priority == 1)
            {
                pendingToVisit.AddFirst(node);
            } else
            {
                pendingToVisit.AddLast(node);
            }
            
        }
        
        public T dequeue()
        {
            T node = pendingToVisit.First.Value;
            pendingToVisit.RemoveFirst();
            return node;
        }
        
        public void clear()
        {
            pendingToVisit.Clear();
        }
        
        public bool contains(T node)
        {
            return pendingToVisit.Contains(node);
        }
        
    }
}
