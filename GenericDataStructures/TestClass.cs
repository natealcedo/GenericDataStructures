using System;

namespace GenericDataStructures
{
    public class TestClass
    {
        static void Main()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Clear();
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

        }
    }
}

