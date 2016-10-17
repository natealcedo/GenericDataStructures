
using System;
using System.Collections;
using System.Linq;

namespace GenericDataStructures
{
    /// <summary>
    /// This is a singly Linked List Data Structure.
    /// </summary>
    public class SingleLinkedList<T>: ISingleLinkedList<T>, IEnumerable
    {
        /// <summary>
        /// This is the Node class that the list uses.
        /// </summary>
        private class Node
        {
            public T Value { get; private set; }
            public Node NextNode{ get; set;}
            public Node(T element)
            {
                Value = element;
                NextNode = null;
            }
            public Node(T element, Node previousNode): this(element)
            {
                previousNode.NextNode = this;
                NextNode = null;
            }
        }
        /// <summary>
        /// Head of the list.
        /// </summary>
        private Node Head;
        /// <summary>
        /// Tail of the list.
        /// </summary>
        private Node Tail;
        /// <summary>
        /// This is the implementation of the interace property.
        /// </summary>
        /// <value>Number of elements in the list</value>
        public int Count { get; private set;}
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDataStructures.SingleLinkedList`1"/> class.
        /// </summary>
        public SingleLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// This is an implementation of the interface method
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// This is an implementation of the interface method
        /// </summary>
        /// <returns>Returns true if operation was successful. False if otherwise.</returns>
        /// <param name="element">Element to be added.</param>
        public bool Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            Node nodeToAdd = null;
            if (Count == 0)
            {
                nodeToAdd = new Node(element);
                Head = nodeToAdd;
                Tail = Head;
                Count++;
                return true;
            }
            else
            {
                nodeToAdd = new Node(element, Tail);
                Tail = nodeToAdd;
                Count++;
                return true;
            }
        } 
        /// <summary>
        /// This is the implementation of the interface method.
        /// </summary>
        /// <returns>True if operation was successful. False if otherwise</returns>
        /// <param name="element">Element to be removed from the list</param>
        public bool Remove(T element)
        {
            Node nodeBeforeFoundNode = null;
            var currentNode = Head;
            if (element == null)
            {
                return false;
            }
            if (Count == 0)
            {
                return false;
            }
            while (!Equals(currentNode.Value, element))
            {
                nodeBeforeFoundNode.NextNode = currentNode;
                currentNode = currentNode.NextNode;
            }
            // Element was not found in the list.
            if (Equals(currentNode, null))
            {
                return false; 
            }
            // 2 cases,
            // 1. Head is to be removed
            // 2. Element to be removed is not the head
            if (currentNode == Head)
            {
                Head = currentNode.NextNode;
                Count--;
                return true;
            }
            nodeBeforeFoundNode.NextNode = currentNode.NextNode;
            Count--;
            return true;
        }
        /// <summary>
        /// This is an implementation of the interface method.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <returns>True if operation was successful. False if otherwise.</returns>
        public bool Contains(T element)
        {
            if (Count == 0)
            {
                return false;
            }
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            Node current = Head;
            while(!Equals(current, Tail))
            {
                current = current.NextNode;
            }
            if (Equals(current, null))
            {
                return false;
            }
            return true;
         }
        /// <summary>
        /// Implements the GetEnumerator method to allow the use
        ///  of foreach method in this class
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextNode;
            }
        }
    }
}
