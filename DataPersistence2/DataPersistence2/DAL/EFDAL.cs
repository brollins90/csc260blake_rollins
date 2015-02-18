using DataPersistence2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataPersistence2.DAL
{
    public class EFDAL : IDAL
    {
        ProductDBContext context;

        public EFDAL()
        {
            context = new ProductDBContext();
        }

        public bool AddProduct(Product product)
        {
            context.Products.Add(product);
            return SaveProducts();
        }

        public bool SaveProducts()
        {
            return (context.SaveChanges() != 0);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return context.Products.Where(x => x.Id == id).First();
        }

        public bool UpdateProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            p.UpdateProduct(product);
            return SaveProducts();
        }

        public bool DeleteProduct(int id)
        {
            context.Products.Remove(GetProduct(id));
            return SaveProducts();
        }
    }
}