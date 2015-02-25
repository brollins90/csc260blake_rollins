using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataPersistence3.Models
{
    [Serializable]
    public class ProductList
    {
        public int NextId { get; set; }
        public List<Product> Products { get; set; }

        public ProductList()
        {
            NextId = 1;
            Products = new List<Product>();
        }
    }
}