using DataPersistence3.Interfaces;
using DataPersistence3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataPersistence3.DAL
{
    public class FlatFileDal : IDal
    {
        public string Path { get; set; }
        private ProductList _productList;

        public FlatFileDal(string path)
        {
            Path = path;
        }

        public bool AddProduct(Product product)
        {
            if (_productList == null)
            {
                _productList = Deserialize("products.bin");
            }
            product.Id = _productList.NextId++;
            _productList.Products.Add(product);
            return SaveProducts();
        }

        public bool SaveProducts()
        {
            try
            {
                Serialize(_productList, "products.bin");
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(string.Format("Failed to save product list: {0}", e.Message));
                return false;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            if (_productList == null)
            {
                _productList = Deserialize("products.bin");
            }
            return _productList.Products;
        }

        public Product GetProduct(int id)
        {
            IEnumerable<Product> products = GetProducts();
            return products.First(x => x.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            IEnumerable<Product> products = GetProducts();
            Product p = products.FirstOrDefault(x => x.Id == product.Id);
            if (p != null)
            {
                p.UpdateProduct(product);
            }
            return SaveProducts();
        }

        public bool DeleteProduct(int id)
        {
            if (_productList == null)
            {
                _productList = Deserialize("products.bin");
            }
            _productList.Products.Remove(GetProduct(id));
            return SaveProducts();
        }

        private void Serialize(ProductList pList, string filename)
        {
            Stream ms = File.OpenWrite(String.Format("{0}\\{1}", Path, filename));
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, pList);
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
                Trace.WriteLine(string.Format("Failed to deserialize product list: {0}", e.Message));
                return new ProductList();
            }
        }
    }
}