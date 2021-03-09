using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreMVC.Models
{
    public class Mapper : IMapper
    {
        public CustomerIndexVM Cast2CustomerIndexVM(Customer customer2BCasted)
        {
            return new CustomerIndexVM
            {
                FirstName = customer2BCasted.FirstName,
                LastName = customer2BCasted.LastName,
                PhoneNumber = customer2BCasted.PhoneNumber
            };
        }
        public Customer Cast2Customer(CustomerCRVM customer2BCasted)
        {
            return new Customer
            {
                FirstName = customer2BCasted.FirstName,
                LastName = customer2BCasted.LastName,
                PhoneNumber = customer2BCasted.PhoneNumber
            };
        }
        public CustomerCRVM Cast2CustomerCRVM(Customer customer2BCasted)
        {
            return new CustomerCRVM
            {
                FirstName = customer2BCasted.FirstName,
                LastName = customer2BCasted.LastName,
                PhoneNumber = customer2BCasted.PhoneNumber
            };
        }
        public LocationIndexVM Cast2LocationIndexVM(Location location)
        {
            return new LocationIndexVM
            {
                LocationID = location.LocationID,
                Address = location.Address,
                State = location.State,
                LocationName = location.LocationName
            };
        }
    }
}
