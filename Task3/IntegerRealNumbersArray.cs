using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class IntegerRealNumbersArray
    {
        private Tuple<int, double>[] array;
        public IntegerRealNumbersArray(int length)
        {
            array = new Tuple<int, double>[length];
        }

        public int Length
        {
            get { return array.Length; }
        }

        public Tuple<int, double> this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
        public void Add(int integerValue, double realVavue)
        {
            Tuple<int, double>[] newArray = new Tuple<int, double>[Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[Length] = new Tuple<int, double>(integerValue, realVavue);
            array = newArray;
        }

        public void Insert(int index, Tuple<int, double> tuple)
        {
            Tuple<int, double>[] newArray = new Tuple<int, double>[Length + 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }
            newArray[index] = tuple;
            for (int i = index + 1; i < newArray.Length; i++)
            {
                newArray[i] = array[i - 1];
            }
        }
        public void Insert(int index, int integerValue, double realVavue) => Insert(index, new Tuple<int, double>(integerValue, realVavue));
        public void Remove(Tuple<int, double> tuple)
        {
            if (array.Contains(tuple))
            {
                Tuple<int, double>[] newArray = new Tuple<int, double>[Length - 1];
                for (int i = 0; i < IndexOf(tuple); i++)
                {
                    newArray[i] = array[i];
                }
                for (int i = IndexOf(tuple); i < newArray.Length; i++)
                {
                    newArray[i] = array[i + 1];
                }
                array = newArray;
            }
        }
        public void Remove(int integerValue, double realVavue) => Remove(new Tuple<int, double>(integerValue, realVavue));

        public void RemoveAt(int index)
        {
            if (index > 0 && index < array.Length)
            {
                Tuple<int, double>[] newArray = new Tuple<int, double>[Length - 1];
                for (int i = 0; i < index; i++)
                {
                    newArray[i] = array[i];
                }
                for (int i = index; i < newArray.Length; i++)
                {
                    newArray[i] = array[i + 1];
                }
                array = newArray;
            }
            else
            {
                throw new IndexOutOfRangeException("RemoveAt, argument index out of range");
            }
        }

        public int IndexOf(Tuple<int, double> tuple)
        {
            if (array.Contains(tuple))
            {
                Tuple<int, double>[] newArray = new Tuple<int, double>[Length - 1];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == tuple)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public void Clear()
        {
            array = Array.Empty<Tuple<int, double>>();
        }

        public void DisplayArray()
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        public IEnumerator<Tuple<int, double>> GetEnumerator()
        {
            foreach (var item in array)
            {
                yield return item;
            }
        }
    }
}
