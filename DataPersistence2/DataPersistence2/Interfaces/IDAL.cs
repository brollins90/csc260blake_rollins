using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence2.Interfaces
{
    public interface IDAL
    {
        bool AddProduct(Product product);

        bool SaveProducts();

        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);

    }
}
