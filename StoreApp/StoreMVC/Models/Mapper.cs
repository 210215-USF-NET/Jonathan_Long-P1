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
        public ItemCRVM Cast2ItemCRVM(Item item2BCasted)
        {
            return new ItemCRVM
            {
                ItemID = item2BCasted.ItemID,
                Quantity = item2BCasted.Quantity,
                ProductID = item2BCasted.Product.ProductID,
                ProductName = item2BCasted.Product.ProductName,
                Price = item2BCasted.Product.Price,
                Description = item2BCasted.Product.Description,
                LocationID = item2BCasted.Location.LocationID,
                Address = item2BCasted.Location.Address,
                State = item2BCasted.Location.State,
                LocationName = item2BCasted.Location.LocationName
            };
        }
        public ProductCRVM Cast2ProductCRVM(Product item2BCasted)
        {
            return new ProductCRVM
            {
                ProductID = item2BCasted.ProductID,
                ProductName = item2BCasted.ProductName,
                Price = item2BCasted.Price,
                Description = item2BCasted.Description
            };
        }
        public LocationCRVM Cast2LocationCRVM(Location item2BCasted)
        {
            return new LocationCRVM
            {
                LocationID = item2BCasted.LocationID,
                LocationName = item2BCasted.LocationName,
                Address = item2BCasted.Address,
                State = item2BCasted.State
            };
        }
    }
}
