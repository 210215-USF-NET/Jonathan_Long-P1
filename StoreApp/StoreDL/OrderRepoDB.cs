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
    /// Data layer for orders
    /// </summary>
    public class OrderRepoDB : IOrderRepository
    {
        private readonly StoreDBContext _context;
        public OrderRepoDB(StoreDBContext context)
        {
            _context = context;
        }
        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public Order FindOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public Order FindOrder(double totalCost)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrders(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersASC(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersASCTotal(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersDESC(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrdersDESCTotal(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderASC(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderASCTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderDESC(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderDESCTotal(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
