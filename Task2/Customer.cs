using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Customer
    {
        private static int idCounter = 0;
        public int Id { get; }
        public string Name { get; set; }
        public Customer(string name)
        {
            Id = ++idCounter;
            Name = name;
        }
        public override string ToString()
        {
            return $"({Id}){Name}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj is Customer)
            {
                return ((Customer)obj).Id == Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
