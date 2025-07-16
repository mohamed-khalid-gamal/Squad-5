using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Product
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Product ID: {Id}, Name: {Name}, Price: {Price:C}";
        }
    }
}
