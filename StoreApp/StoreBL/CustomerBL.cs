using System;
using StoreModels;
using StoreDL;
using System.Collections.Generic;

namespace StoreBL
{
    /// <summary>
    /// This class enforces the business rules for our Customers
    /// </summary>
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository _repo;
        public CustomerBL(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public Customer AddCustomer(Customer newCustomer)
        {
            return _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }
    }
}
