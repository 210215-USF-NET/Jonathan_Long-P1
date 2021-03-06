using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
        Customer GetCustomerByName(string firstName, string lastName);
        Customer GetCustomerByID(int custID);
    }
}