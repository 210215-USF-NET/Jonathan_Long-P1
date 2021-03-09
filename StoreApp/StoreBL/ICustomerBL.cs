using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ICustomerBL
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
        Customer GetCustomerByName(string firstName, string lastName);
    }
}