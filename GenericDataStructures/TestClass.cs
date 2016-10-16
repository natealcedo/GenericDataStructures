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

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}

