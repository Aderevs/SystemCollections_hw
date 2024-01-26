using System.Collections.Generic;
using System.Xml.Linq;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntegerRealNumbersArray array = new IntegerRealNumbersArray(5);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Tuple<int, double>(i, (double)i * 2 / 5);
            }
            Console.WriteLine("Original array");
            array.DisplayArray();

            array.RemoveAt(3);
            array.Add(7, 3.44);

            Console.WriteLine("Changed array");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 28));

            IntegerRrealLinkedList linkedList = new IntegerRrealLinkedList();
            linkedList.AddNode(1, 1.1);
            linkedList.AddNode(2, 2.2);
            linkedList.AddNode(3, 3.3);

            Console.WriteLine("Original List:");
            linkedList.DisplayList();

            linkedList.RemoveNode(2, 2.2);

            Console.WriteLine("\nList after removing (2, 2.2):");
            linkedList.DisplayList();

            linkedList.AddNodeAtIndex(1, 5, 5.5);

            Console.WriteLine("\nList after adding (5, 5.5) at index 1:");
            linkedList.DisplayList();

            linkedList.RemoveNodeAtIndex(0);

            Console.WriteLine("\nList after removing element at index 0:");
            linkedList.DisplayList();

            Console.WriteLine("\nElement at index 1:");
            var elementAtIndex1 = linkedList[1];
            Console.WriteLine($"IntData: {elementAtIndex1.Item1}, DoubleData: {elementAtIndex1.Item2}");

            Console.WriteLine();
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
