using System;
using System.Collections;
using System.Linq;

namespace GenericDataStructures
{
    public sealed class ArrayList<T>: IArrayList<T>, IEnumerable
    {
        private const int DEFAULT_SIZE = 8;
        private T[] listArray;
        private int arrayElementCounter = 0;
        private T[] newArrayForCopying = null;

        public ArrayList()
        {
            listArray = new T[DEFAULT_SIZE];
        }

        public int Count{get{return this.arrayElementCounter;}}

        public void Add(T element)
        {
            growIfArrayIsFull();
            this.listArray[arrayElementCounter] = element;
            this.arrayElementCounter++;
        }

        public void Remove(T element)
        {
            int indexOfFoundElement = IndexOf(element);
            if (indexOfFoundElement != -1)
            {
                newArrayForCopying = new T[listArray.Length];
                // 3 cases to handle
                // Case 1. only one element in the list
                if (arrayElementCounter == 1)
                {
                    IfElementToBeRemovedIsHeadAndTheOnlyElement();
                    return;
                }
                // Case 2. Element To be removed is head but not the only element
                else if (Equals(listArray[0], element) && arrayElementCounter > 1)
                {
                    IfElementToBeRemovedIsHeadButNotTheOnlyElement(newArrayForCopying);
                    return;
                }
                // Case 3. Element to be removes is not the head and not the only one in the list
                else if(indexOfFoundElement > 0 && indexOfFoundElement < arrayElementCounter) // The element To be removed is not the tail
                {
                    IfElementToBeRemoveIsNotHeadAndNotIsNotTail(newArrayForCopying, indexOfFoundElement);
                    return;
                }
            }

            return;
        }

        public void RemoveAt(int index)
        {
            newArrayForCopying = new T[listArray.Length];
            if (index < 0 || index > listArray.Count())
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == 0 && arrayElementCounter == 1)
            {
                IfElementToBeRemovedIsHeadAndTheOnlyElement();
                return;
            }
            else if (index == 0 && arrayElementCounter > 1)
            {
                IfElementToBeRemovedIsHeadButNotTheOnlyElement(newArrayForCopying);
                return;
            }
            else if (index > 0 && index < arrayElementCounter)
            {
                IfElementToBeRemoveIsNotHeadAndNotIsNotTail(newArrayForCopying, index);
                return;
            }
            else
            {
                IfElementIsTail(newArrayForCopying);
                return;
            }

        }

        public void Clear()
        {
            listArray = new T[DEFAULT_SIZE];
        }

        public bool Contains(T element)
        {
            for (int i = 0; i <= arrayElementCounter; i++)
            {
                if (this.listArray.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        private void growIfArrayIsFull()
        {
            T[] newListArray;
            if (this.arrayElementCounter == this.listArray.Length)
            {
                newListArray = new T[this.listArray.Length * 2];
                Array.Copy(listArray, newListArray, arrayElementCounter);
                listArray = newListArray;
            }
            return;
        }

        public IEnumerator GetEnumerator()
        {
            // This is not the most elegant solution. 
            // Will Change it when I understand more about 
            // what the this method is supposed to return
            return listArray.Take(arrayElementCounter).GetEnumerator();
        }

        public int IndexOf(T element)
        {
            // returns index of first instance of an element if present in the list
            // else returns an index of -1
            int index = 0;
            while (index != arrayElementCounter)
            {
                if (Equals(element, listArray[index]))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void IfElementToBeRemovedIsHeadAndTheOnlyElement()
        {
            listArray = new T[DEFAULT_SIZE];
            arrayElementCounter--;
            return;
        }

        private void IfElementToBeRemovedIsHeadButNotTheOnlyElement(T[] arrayForCopying)
        {
            Array.Copy(listArray, 1, arrayForCopying, 0, this.Count -1);
            arrayElementCounter--;
            listArray = arrayForCopying;
            return;
        }

        private void IfElementToBeRemoveIsNotHeadAndNotIsNotTail(T[] arrayForCopying, int indexOfElementToRemove)
        {
            Array.Copy(listArray, 0, arrayForCopying, 0, indexOfElementToRemove + 1);
            Array.Copy(listArray, indexOfElementToRemove + 1, arrayForCopying, indexOfElementToRemove, arrayElementCounter - indexOfElementToRemove);
            listArray = arrayForCopying;
            arrayElementCounter--;
        }

        private void IfElementIsTail(T[] arrayForCopying)
        {
            Array.Copy(listArray, 0, arrayForCopying, 0, arrayElementCounter -1);
            listArray = arrayForCopying;
            arrayElementCounter--;
            return;
        }
    }
}
