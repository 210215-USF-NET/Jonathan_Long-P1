using System.Collections.Generic;
using StoreModels;
using StoreDL;
namespace StoreBL
{
    /// <summary>
    /// This class is responsible for handling all the business logic for the Product class
    /// </summary>
    public class ProductBL : IProductBL
    {
        private IProductRepository _repo;
        public ProductBL(IProductRepository repo)
        {
            _repo = repo;
        }

        public Product GetProductByID(int productID)
        {
            return _repo.GetProductByID(productID);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public void ProductsByOrder(int orderID)
        {
            _repo.ProductsByOrder(orderID);
        }
    }
}