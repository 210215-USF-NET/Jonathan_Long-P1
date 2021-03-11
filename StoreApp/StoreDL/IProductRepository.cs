using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void ProductsByOrder(int orderID);
        Product GetProductByID(int productID);
        Product GetProductByName(string productName);
    }
}