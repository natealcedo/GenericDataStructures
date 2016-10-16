using System;
using System.Collections;

namespace GenericDataStructures
{
    public interface ISingleLinkedList<T>
    {
        int Count {get;set;}
        void Add (T element);
        void Remove(T element);
        void Clear();
        bool Contains(T element);

    }
}

