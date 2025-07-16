using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ProductService
    {
        private readonly List<Product> _products;
        private int _nextId;

        public ProductService()
        {
            _products = new List<Product>();
            _nextId = 1;
        }

        public Product CreateProduct(string name, decimal price, int catId = 0)
        {
            var product = new Product(_nextId++, name, price)
            {
                CatId = catId
            };
            _products.Add(product);
            return product;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return _products.ToList();
        }

        public List<Product> GetProductsByCategory(int catId)
        {
            return _products.Where(p => p.CatId == catId).ToList();
        }

        public List<Product> SearchProductsByName(string name)
        {
            return _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public bool UpdateProduct(int id, string name = null, decimal? price = null, int? catId = null)
        {
            var product = GetProductById(id);
            if (product == null)
                return false;

            if (name != null)
                product.Name = name;
            if (price.HasValue)
                product.Price = price.Value;
            if (catId.HasValue)
                product.CatId = catId.Value;

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null)
                return false;

            _products.Remove(product);
            return true;
        }

        public void DeleteAllProducts()
        {
            _products.Clear();
        }

        public int GetProductCount()
        {
            return _products.Count;
        }

        public bool ProductExists(int id)
        {
            return _products.Any(p => p.Id == id);
        }

        public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }
    }
}
