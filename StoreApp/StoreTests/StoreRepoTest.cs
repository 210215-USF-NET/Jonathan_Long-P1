using Xunit;
using Microsoft.EntityFrameworkCore;
using StoreDL;
using System.Linq;
using StoreModels;

namespace StoreTests
{
    /// <summary>
    /// Test class for data access methods in my DL for store application
    /// </summary>
    public class StoreRepoTest
    {
        private readonly DbContextOptions<StoreDBContext> options;
        public StoreRepoTest()
        {
            options = new DbContextOptionsBuilder<StoreDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;

            Seed();
        }
        //Testing Read Operations
        
        [Fact]
        public void GetAllCustomersShouldReturnAllCustomers()
        {
            using(var context = new StoreDBContext(options))
            {
                //Arrange
                ICustomerRepository _repo = new CustomerRepoDB(context);
                //Act
                var customer = _repo.GetCustomers();
                Assert.Equal(2, customer.Count);
            }
        }
        
        [Fact]
        public void GetAllLocationsShouldReturnAllLocations()
        {
            using(var context = new StoreDBContext(options))
            {
                ILocationRepository _repo = new LocationRepoDB(context);
                var location = _repo.GetLocations();
                Assert.Equal(2, location.Count());
            }
        }
        [Fact]
        public void SearchSpecificLocationShouldReturnLocation()
        {
            using(var context = new StoreDBContext(options))
            {
                ILocationRepository _repo = new LocationRepoDB(context);
                var location = _repo.GetSpecificLocation(0);
                Assert.Equal(location, location);
            }
        }
        [Fact]
        public void SearchLocationByName()
        {
            using (var context = new StoreDBContext(options))
            {
                ILocationRepository _repo = new LocationRepoDB(context);
                var location = _repo.GetLocationByName("Ski Buy");
                Assert.NotNull(location);

            }
        }
        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new StoreDBContext(options))
            {
                ICustomerRepository _repo = new CustomerRepoDB(context);
                _repo.AddCustomer
                    (
                        new Customer
                        {
                            FirstName = "Zach",
                            LastName = "French",
                            PhoneNumber = "508-230-4567"
                        }
                    );
            }
            using (var assertContext = new StoreDBContext(options))
            {
                var result = assertContext.Customers.FirstOrDefault(cust => cust.FirstName == "Zach" && cust.LastName == "French");
                Assert.NotNull(result);
            }
        }
        [Fact]
        public void SearchCustomerByName()
        {
            using(var context = new StoreDBContext(options))
            {
                ICustomerRepository _repo = new CustomerRepoDB(context);
                var item = _repo.GetCustomerByName("Tom", "Brady");
                Assert.NotNull(item);
            }
        }
        [Fact]
        public void SearchForItemShouldReturnSpecificItem()
        {
            using(var context = new StoreDBContext(options))
            {
                IItemRepository _repo = new ItemRepoDB(context);
                var item = _repo.GetItemByID(0);
                Assert.Equal(item, item);
            }
        }
        [Fact]
        public void SearchForProductShouldReturnProduct()
        {
            using(var context = new StoreDBContext(options))
            {
                IProductRepository _repo = new ProductRepoDB(context);
                var product = _repo.GetProducts();
                Assert.Equal(2, product.Count());
            }
        }
        [Fact]
        public void ProductSearch()
        {
            using (var context = new StoreDBContext(options))
            {
                IProductRepository _repo = new ProductRepoDB(context);
                var product = _repo.GetProductByName("Skis");
                Assert.NotNull(product);
            }
        }
        private void Seed()
        {
            using(var context = new StoreDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Customers.AddRange
                (
                    new Customer
                    {
                        FirstName = "Jack",
                        LastName = "Long",
                        PhoneNumber = "123-444-5678"
                    },
                     new Customer
                    {
                        FirstName = "Tom",
                        LastName = "Brady",
                        PhoneNumber = "145-464-5690"
                    }
                );
                context.Locations.AddRange
                (
                    new Location
                    {
                        Address = "123 Way",
                        State = "VA",
                        LocationName = "Ski Store"
                    },
                    new Location
                    {
                        Address = "42 Way",
                        State = "VA",
                        LocationName = "Ski Buy"
                    }
                );
                context.Products.AddRange
                (
                    new Product
                    {
                        ProductName = "Skis",
                        Price = 22,
                        Description = "They are skis"
                    },
                    new Product
                    {
                        ProductName = "Boots",
                        Price = 10,
                        Description = "They are boots"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}