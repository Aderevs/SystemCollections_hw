namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PurchasesList purchasesList = new PurchasesList();

            Customer customer1 = new Customer("John");
            Customer customer2 = new Customer("Alice");
            Customer customer3 = new Customer("Bob");
            Customer customer4 = new Customer("Luck");
            Customer customer5 = new Customer("Simon");
            Customer customer6 = new Customer("Lucy");
            Customer customer7 = new Customer("Elis");
            Customer customer8 = new Customer("Samanta");

            purchasesList.AddPurchase(customer1, "Electronics");
            purchasesList.AddPurchase(customer5, "Electronics");
            purchasesList.AddPurchase(customer2, "Books");
            purchasesList.AddPurchase(customer4, "Books");
            purchasesList.AddPurchase(customer3, "Clothing");
            purchasesList.AddPurchase(customer6, "Clothing");
            purchasesList.AddPurchase(customer1, "Books");
            purchasesList.AddPurchase(customer2, "Electronics");
            purchasesList.AddPurchase(customer3, "Electronics");

            List<string> johnCategories = purchasesList.GetCategoiesOfCustomer(customer1);
            Console.WriteLine($"Categories for {customer1}: {string.Join(", ", johnCategories)}");

            List<Customer> electronicsCustomers = purchasesList.GetCustomersOfCategory("Electronics");
            Console.WriteLine($"Customers who bought Electronics: {string.Join(", ", electronicsCustomers)}");

            Console.WriteLine("\nAll purchases:");
            foreach (var purchase in purchasesList)
            {
                Console.WriteLine($"{purchase.Item1} bought {purchase.Item2}");
            }
        }
    }
}
