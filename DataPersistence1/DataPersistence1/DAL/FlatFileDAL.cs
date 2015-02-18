using DataPersistence1.Interfaces;
using DataPersistence1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace DataPersistence1.DAL
{
    public class FlatFileDAL : IDAL
    {   
        public string Path { get; set; }
        private ProductList pl;

        public FlatFileDAL(string path)
        {
            Path = path;
        }

        public bool AddProduct(Product product)
        {
            if (pl == null)
            {
                pl = Deserialize("products.bin");
            }
            product.Id = pl.NextId++;
            pl.Products.Add(product);
            return SaveProducts();
        }

        public bool SaveProducts()
        {
            try
            {
                Serialize(pl, "products.bin");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Models.Product> GetProducts()
        {
            if (pl == null)
            {
                pl = Deserialize("products.bin");
            }
            return pl.Products;
        }

        public Product GetProduct(int id)
        {
            IEnumerable<Product> products = GetProducts();
            return products.Where(x => x.Id == id).First();
        }

        public bool UpdateProduct(Models.Product product)
        {
            IEnumerable<Product> products = GetProducts();
            Product p = products.Where(x => x.Id == product.Id).FirstOrDefault();
            p.UpdateProduct(product);
            return SaveProducts();
        }

        public bool DeleteProduct(int id)
        {
            if (pl == null)
            {
                pl = Deserialize("products.bin");
            }
            pl.Products.Remove(GetProduct(id));
            return SaveProducts();
        }

        private void Serialize(ProductList PList, string filename)
        {
            System.IO.Stream ms = File.OpenWrite(String.Format("{0}\\{1}",Path, filename));
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, PList);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        private ProductList Deserialize(string filename)
        {

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = File.Open(String.Format("{0}\\{1}", Path, filename), FileMode.Open);

                object obj = formatter.Deserialize(fs);
                ProductList products = (ProductList)obj;
                fs.Flush();
                fs.Close();
                fs.Dispose();
                return products;
            }
            catch (Exception e)
            {
                return new ProductList();
            }
        }
    }
}