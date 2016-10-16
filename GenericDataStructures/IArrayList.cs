using System;

namespace GenericDataStructures
{
    public interface IArrayList<T>
    {
        int Count { get;}
        void Clear();
        bool Contains(T element);
        void Add(T element);
        void Remove(T element);
        void RemoveAt(int index);
        int IndexOf(T element);

    }
}

