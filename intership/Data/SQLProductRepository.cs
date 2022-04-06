using intership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Data
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public SQLProductRepository(ProductContext context)
        {
            _context = context;
        }
        public void CreateProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            else
                throw new ArgumentNullException(nameof(product));
        }

        public void DeleteProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
                throw new ArgumentNullException(nameof(product));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductMatching(string keyword)
        {
            return _context.Products.Where(p => p.Name == keyword);
        }

        public IEnumerable<Product> GetAllProductsSortedASC()
        {
            return _context.Products.OrderBy(p => p).ToList();
        }

        public IEnumerable<Product> GetAllProductsSortedDESC()
        {
            return _context.Products.OrderByDescending(p => p).ToList();
        }

        public Product GetOledestProduct()
        {
            return _context.Products.ToList().Last();
        }

        public Product GetProductById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.id == id);
        }

        public Product GetRecentProduct()
        {
            return _context.Products.FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            //nothing
        }
    }
}
