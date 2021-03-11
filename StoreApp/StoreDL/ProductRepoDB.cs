using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    /// <summary>
    /// Data layer for products
    /// </summary>
    public class ProductRepoDB : IProductRepository
    {
        private readonly StoreDBContext _context;
        public ProductRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Select(product => product).ToList();
        }

        public void ProductsByOrder(int orderID)
        {
            throw new NotImplementedException();
        }
        public Product GetProductByID(int productID)
        {
            return _context.Products.AsNoTracking().Select(product => product).FirstOrDefault(product => product.ProductID == productID);
        }
    }
}
