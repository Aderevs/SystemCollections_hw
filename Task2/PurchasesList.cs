using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class PurchasesList
    {
        private List<(Customer, string)> _list = new List<(Customer, string)>();

        public void AddPurchase(Customer customer, string category)
        {
            _list.Add(new (customer, category));
        }
        public List<string> GetCategoiesOfCustomer(Customer customer)
        {
            var categoriesList = _list
                .Where(purchase => purchase.Item1 == customer)
                .Select(purchase => purchase.Item2).ToList();
            return categoriesList;
        }
        public List<Customer> GetCustomersOfCategory(string category)
        {
            var customersList = _list
                .Where(purchase => purchase.Item2 == category)
                .Select(purchase => purchase.Item1).ToList();
            return customersList;
        }
        public IEnumerator<(Customer, string)> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
