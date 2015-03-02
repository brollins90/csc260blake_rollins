
using System;

namespace DataPersistence3
{
    [Serializable]
    public partial class Product
    {
        public void UpdateProduct(Product newProduct)
        {
            Description = newProduct.Description;
            Name = newProduct.Name;
            Price = newProduct.Price;
        }
    }
}