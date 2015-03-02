using DataPersistence3.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataPersistence3.DAL
{
    public class EfDal : IDal
    {
        private readonly ProductDBContext _context;

        public EfDal()
        {
            _context = new ProductDBContext();
        }

        public bool AddProduct(Product product)
        {
            _context.Products.Add(product);
            return SaveProducts();
        }

        public bool SaveProducts()
        {
            return (_context.SaveChanges() != 0);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.First(x => x.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            p.UpdateProduct(product);
            return SaveProducts();
        }

        public bool DeleteProduct(int id)
        {
            _context.Products.Remove(GetProduct(id));
            return SaveProducts();
        }
    }
}