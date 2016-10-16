using System;
using System.Collections;
using System.Linq;

namespace GenericDataStructures
{
    public class SingleLinkedList<T>: ISingleLinkedList<T>, IEnumerable
    {
        public SingleLinkedList()
        {
            
        }


        private class Node
        {
            public T Value { get; set; }
            public Node NextValue{ get; set;}

        }
    }
}

