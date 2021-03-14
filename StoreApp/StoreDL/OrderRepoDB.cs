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
            Order order2DB = new Order();
            order2DB.Date = newOrder.Date;
            order2DB.Total = newOrder.Total;
            order2DB.CustomerCustID = newOrder.Customer.CustID;
            order2DB.LocationID = newOrder.Location.LocationID;
            _context.Orders.Add(order2DB);
            _context.SaveChanges();
            return newOrder;
        }

        public Order FindOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public Order FindOrder(double totalCost)
        {
            return _context.Orders
            .Include("Customer")
            .AsNoTracking()
            .Include("Location")
            .AsNoTracking()
            .Select(order => order)
            .ToList()
            .FindLast(order => order.Total == totalCost);
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
