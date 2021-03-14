using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    /// <summary>
    /// Data layer for ProductOrder objects 
    /// </summary>
    public class ProductOrderRepo : IProductOrderRepository
    {
        private readonly StoreDBContext _context;
        public ProductOrderRepo(StoreDBContext context)
        {
            _context = context;
        }
        public ProductOrder AddProductOrder(ProductOrder newProductOrder)
        {
            ProductOrder productOrder2DB = new ProductOrder();
            productOrder2DB.Quantity = newProductOrder.Quantity;
            productOrder2DB.OrderID = newProductOrder.Order.OrderID;
            productOrder2DB.ProductID = newProductOrder.Product.ProductID;
            _context.ProductOrders.Add(productOrder2DB);
            _context.SaveChanges();
            return newProductOrder;

        }

        public List<ProductOrder> GetCustomerProductOrders(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<ProductOrder> GetProductOrderByOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<ProductOrder> GetProductOrders()
        {
            throw new NotImplementedException();
        }
    }
}
