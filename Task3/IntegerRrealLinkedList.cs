using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task3
{
    class IntegerRrealLinkedList : IEnumerator
    {
        private Node head;

        public int Length
        {
            get
            {
                Node current = head;
                int counter = 0;
                while (current != null)
                {
                    counter++;
                    current = current.Next;
                }
                return counter;
            }
        }
        public void AddNode(int intData, double doubleData)
        {
            Node newNode = new Node(intData, doubleData);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void DisplayList()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine($"IntData: {current.IntData}, DoubleData: {current.DoubleData}");
                current = current.Next;
            }
        }

        public bool RemoveNode(int intData, double doubleData)
        {
            if (head == null)
            {
                return false;
            }

            if (head.IntData == intData && head.DoubleData == doubleData)
            {
                head = head.Next;
                return true;
            }

            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.IntData == intData && current.Next.DoubleData == doubleData)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void AddNodeAtIndex(int index, int intData, double doubleData)
        {
            Node newNode = new Node(intData, doubleData);

            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1 && current != null; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public bool RemoveNodeAtIndex(int index)
        {
            if (head == null)
            {
                return false;
            }

            if (index == 0)
            {
                head = head.Next;
                return true;
            }

            Node current = head;
            for (int i = 0; i < index - 1 && current != null; i++)
            {
                current = current.Next;
            }

            if (current == null || current.Next == null)
            {
                return false;
            }

            current.Next = current.Next.Next;
            return true;
        }

        public Tuple<int, double> this[int index]
        {
            get
            {
                Node current = head;
                for (int i = 0; i < index && current != null; i++)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return new Tuple<int, double>(current.IntData, current.DoubleData);
            }
        }

        private int Index = -1;


        public Tuple<int, double> Current
        {
            get
            {
                return this[Index];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            Index++;
            if (Index < Length)
            {
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }
        public void Reset()
        {
            Index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        private class Node
        {
            public int IntData { get; set; }
            public double DoubleData { get; set; }
            public Node Next { get; set; }
            public Node(int intData, double doubleData)
            {
                IntData = intData;
                DoubleData = doubleData;
            }
        }
    }
}
