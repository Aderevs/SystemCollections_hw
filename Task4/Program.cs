namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ord = new OrderedDictionary<int, string>(20, "twenty");
            ord.Add(25, "twenty5");
            ord.Add(15, "fifteen");
            ord.Add(16, "sixteen");
            ord.Add(13, "thirteen");
            ord.Add(11, "eleven");
            ord.Add(9, "nine");
            ord.Add(14, "fourteen");
            ord.Add(23, "twenty3");
            foreach (var item in ord)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            foreach (var item in ord)
            {
                Console.WriteLine(item);
            }
        }
    }
}
