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
        public List<ProductOrder> GetProductsByOrderID(int orderID)
        {
            var queryProducts =
            (from productOrder in _context.ProductOrders
             where productOrder.OrderID == orderID
             select productOrder).ToList();
            if(queryProducts == null)
            {
                return null;
            }
            List<ProductOrder> returnList = new List<ProductOrder>();
            foreach(var item in queryProducts)
            {
                item.Order = _context.Orders.Find(item.OrderID);
                item.Product = _context.Products.Find(item.ProductID);
                ProductOrder productOrder = item;
                returnList.Add(productOrder);
            }
            return returnList;
        }
        //Get orders by date ascending
        public List<Order> GetCustomerOrdersASC(int custID)
        {

            var queryCustOrders =
            (from order in _context.Orders
             join customer in _context.Customers
             on order.CustomerCustID equals customer.CustID
             where customer.CustID == custID
             orderby order.Date
             select order).ToList();
            if (queryCustOrders == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryCustOrders)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }
        //Get orders by total ascending
        public List<Order> GetCustomerOrdersASCTotal(int custID)
        {
            var queryCustOrders =
            (from order in _context.Orders
             join customer in _context.Customers
             on order.CustomerCustID equals customer.CustID
             where customer.CustID == custID
             orderby order.Total
             select order).ToList();
            if (queryCustOrders == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryCustOrders)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }
        //Get orders by date descending
        public List<Order> GetCustomerOrdersDESC(int custID)
        {
            var queryCustOrders =
            (from order in _context.Orders
            join customer in _context.Customers
            on order.CustomerCustID equals customer.CustID
            where customer.CustID == custID
            orderby order.Date descending
            select order).ToList();
            if (queryCustOrders == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryCustOrders)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }
        //Get orders by total descending
        public List<Order> GetCustomerOrdersDESCTotal(int custID)
        {
            var queryCustOrders =
            (from order in _context.Orders
            join customer in _context.Customers
            on order.CustomerCustID equals customer.CustID
            where customer.CustID == custID
            orderby order.Total descending
            select order).ToList();
            if (queryCustOrders == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryCustOrders)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }
        //Get location orders sorted by date ascending
        public List<Order> GetLocationOrderASC(int locationID)
        {
            var queryLocations =
            (from order in _context.Orders
             join location in _context.Locations
             on order.LocationID equals location.LocationID
             join cust in _context.Customers
             on order.CustomerCustID equals cust.CustID
             where location.LocationID == locationID
             orderby order.Date
             select order).ToList();
            if (queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryLocations)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }

        public List<Order> GetLocationOrderASCTotal(int locationID)
        {
            var queryLocations =
            (from order in _context.Orders
             join location in _context.Locations
             on order.LocationID equals location.LocationID
             join cust in _context.Customers
             on order.CustomerCustID equals cust.CustID
             where location.LocationID == locationID
             orderby order.Total
             select order).ToList();
            if (queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryLocations)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }

        public List<Order> GetLocationOrderDESC(int locationID)
        {
            var queryLocations =
            (from order in _context.Orders
             join location in _context.Locations
             on order.LocationID equals location.LocationID
             join cust in _context.Customers
             on order.CustomerCustID equals cust.CustID
             where location.LocationID == locationID
             orderby order.Date descending
             select order).ToList();
            if (queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryLocations)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }

        public List<Order> GetLocationOrderDESCTotal(int locationID)
        {
            var queryLocations =
            (from order in _context.Orders
             join location in _context.Locations
             on order.LocationID equals location.LocationID
             join cust in _context.Customers
             on order.CustomerCustID equals cust.CustID
             where location.LocationID == locationID
             orderby order.Total descending
             select order).ToList();
            if (queryLocations == null)
                return null;
            List<Order> returnList = new List<Order>();
            foreach (var item in queryLocations)
            {
                item.Customer = _context.Customers.Find(item.CustomerCustID);
                item.Location = _context.Locations.Find(item.LocationID);
                Order newOrder = item;
                returnList.Add(newOrder);
            }
            return returnList;
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
