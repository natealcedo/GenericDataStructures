using System;
using System.Collections;
using System.Linq;

namespace GenericDataStructures
{
    public class SingleLinkedList<T>: ISingleLinkedList<T>//, IEnumerable
    {
        private Node Head;
        private Node Tail;
        public int Count { get; private set; }

        public SingleLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Add(T element)
        {
            Node nodeToAdd = null;
            if (this.Count == 0)
            {
                nodeToAdd = new Node(element);
                this.Head = nodeToAdd;
                this.Tail = this.Head;
                this.Count++;
                return;
            }
            else
            {
                nodeToAdd = new Node(element, this.Tail);
                this.Tail = nodeToAdd;
                this.Count++;

            }
        }

        private class Node
        {
            public T Value { get; set; }
            public Node NextNode{ get; set;}

            public Node(T element)
            {
                Value = element;
                this.NextNode = null;
            }

            public Node(T element, Node previousNode): this(element)
            {
                previousNode.NextNode = this;
                this.NextNode = null;

            }
        }
    }
}

