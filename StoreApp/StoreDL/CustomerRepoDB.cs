using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreDL
{
    public class CustomerRepoDB : ICustomerRepository
    {
        private readonly StoreDBContext _context;
        public CustomerRepoDB(StoreDBContext context)
        {
            _context = context;
        }
        public Customer AddCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().Select(cust => cust).ToList();
        }
    }
}
