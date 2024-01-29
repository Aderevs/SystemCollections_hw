namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ord = new OrderedDictionary<int, string>(20, "twenty")
            {
                { 25, "twenty5" },
                { 15, "fifteen" },
                { 16, "sixteen" },
                { 13, "thirteen" },
                { 11, "eleven" },
                { 9, "nine" },
                { 14, "fourteen" },
                { 23, "twenty3" }
            };
            foreach (var item in ord)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            ord.RemoveWithKey(14);
            foreach (var item in ord)
            {
                Console.WriteLine(item);
            }
        }
    }
}
