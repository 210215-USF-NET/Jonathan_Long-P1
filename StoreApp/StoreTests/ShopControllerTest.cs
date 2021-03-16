using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using StoreBL;
using StoreModels;
using StoreMVC.Controllers;
using StoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreTests
{
    public class ShopControllerTest
    {
        [Fact]
        public void ShopControllerShouldReturnIndex()
        {
            //Creating a Stub ILocationBL using Moq framework
            var mockRepoProductOrder = new Mock<IProductOrderBL>();
            var mockRepoProduct = new Mock<IProductBL>();
            var mockRepoOrder = new Mock<IOrderBL>();
            var mockRepoItem = new Mock<IItemBL>();
            var mockRepoCust = new Mock<ICustomerBL>();
            var mockRepo = new Mock<ILocationBL>();
            mockRepo.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
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
                }
                );
            var controller = new ShopController(mockRepo.Object, new Mapper(), mockRepoItem.Object, mockRepoProduct.Object, mockRepoCust.Object,
                mockRepoOrder.Object, mockRepoProductOrder.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void ShopControllerShouldReturnTwoLocations()
        {
            //Creating a Stub ILocationBL using Moq framework
            var mockRepoProductOrder = new Mock<IProductOrderBL>();
            var mockRepoProduct = new Mock<IProductBL>();
            var mockRepoOrder = new Mock<IOrderBL>();
            var mockRepoItem = new Mock<IItemBL>();
            var mockRepoCust = new Mock<ICustomerBL>();
            var mockRepo = new Mock<ILocationBL>();
            mockRepo.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
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
                }
                );
            var controller = new ShopController(mockRepo.Object, new Mapper(), mockRepoItem.Object, mockRepoProduct.Object, mockRepoCust.Object,
                mockRepoOrder.Object, mockRepoProductOrder.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<LocationIndexVM>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        [Fact]
        public void ShopControllerAddToCartView()
        {
            //Creating a Stub ILocationBL using Moq framework
            var mockRepoProductOrder = new Mock<IProductOrderBL>();
            var mockRepoProduct = new Mock<IProductBL>();
            var mockRepoOrder = new Mock<IOrderBL>();
            var mockRepoItem = new Mock<IItemBL>();
            var mockRepoCust = new Mock<ICustomerBL>();
            var mockRepo = new Mock<ILocationBL>();
            mockRepo.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
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
                }
                );
            var controller = new ManagerController(mockRepoCust.Object, new Mapper(), mockRepo.Object, mockRepoProduct.Object, mockRepoOrder.Object, mockRepoItem.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void ManagerControllerCreateIsView()
        {
            //Creating a Stub ILocationBL using Moq framework
            var mockRepoProductOrder = new Mock<IProductOrderBL>();
            var mockRepoProduct = new Mock<IProductBL>();
            var mockRepoOrder = new Mock<IOrderBL>();
            var mockRepoItem = new Mock<IItemBL>();
            var mockRepoCust = new Mock<ICustomerBL>();
            var mockRepo = new Mock<ILocationBL>();
            mockRepo.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
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
                }
                );
            var controller = new ManagerController(mockRepoCust.Object, new Mapper(), mockRepo.Object, mockRepoProduct.Object, mockRepoOrder.Object, mockRepoItem.Object);
            var result = controller.Create();
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void ManagerControllerViewLocations()
        {
            //Creating a Stub ILocationBL using Moq framework
            var mockRepoProductOrder = new Mock<IProductOrderBL>();
            var mockRepoProduct = new Mock<IProductBL>();
            var mockRepoOrder = new Mock<IOrderBL>();
            var mockRepoItem = new Mock<IItemBL>();
            var mockRepoCust = new Mock<ICustomerBL>();
            var mockRepo = new Mock<ILocationBL>();
            mockRepo.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
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
                }
                );
            var controller = new ManagerController(mockRepoCust.Object, new Mapper(), mockRepo.Object, mockRepoProduct.Object, mockRepoOrder.Object, mockRepoItem.Object);
            var result = controller.ViewLocations();
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void ManagerControllerViewLocationType()
        {
            //Creating a Stub ILocationBL using Moq framework
            var mockRepoProductOrder = new Mock<IProductOrderBL>();
            var mockRepoProduct = new Mock<IProductBL>();
            var mockRepoOrder = new Mock<IOrderBL>();
            var mockRepoItem = new Mock<IItemBL>();
            var mockRepoCust = new Mock<ICustomerBL>();
            var mockRepo = new Mock<ILocationBL>();
            mockRepo.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
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
                }
                );
            var controller = new ManagerController(mockRepoCust.Object, new Mapper(), mockRepo.Object, mockRepoProduct.Object, mockRepoOrder.Object, mockRepoItem.Object);
            var result = controller.ViewLocations();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Location>>(viewResult.ViewData.Model);
        }
    }
}
