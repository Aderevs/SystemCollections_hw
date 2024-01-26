using System.Collections;

namespace Task6
{
    internal class Program
    {
        class StringReversComparer:IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return new CaseInsensitiveComparer().Compare(y, x);
            }
        }
        static void Main(string[] args)
        {
            SortedList<string, int> list = new SortedList<string, int>();
            list.Add("one", 1);
            list.Add("two", 2);
            list.Add("three", 3);
            list.Add("four", 4);
            list.Add("five", 5);

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine(new string('-', 25));

            StringReversComparer stringReversComparer = new StringReversComparer();
            list = new SortedList<string, int>(stringReversComparer);
            list.Add("one", 1);
            list.Add("two", 2);
            list.Add("three", 3);
            list.Add("four", 4);
            list.Add("five", 5);

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
