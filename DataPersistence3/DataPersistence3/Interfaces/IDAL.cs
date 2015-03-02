using System.Collections.Generic;

namespace DataPersistence3.Interfaces
{
    public interface IDal
    {
        bool AddProduct(Product product);

        bool SaveProducts();

        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);

    }
}
