using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataPersistence2
{
    public partial class Product
    {
        public void UpdateProduct(Product newProduct)
        {
            this.Description = newProduct.Description;
            this.Name = newProduct.Name;
            this.Price = newProduct.Price;
        }
    }
}