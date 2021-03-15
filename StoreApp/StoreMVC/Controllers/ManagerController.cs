using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreMVC.Models;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Controllers
{
    /// <summary>
    /// Controller for the manager
    /// </summary>
    public class ManagerController : Controller
    {
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IOrderBL _orderBL;
        private IMapper _mapper;
        public ManagerController(ICustomerBL customerBL, IMapper mapper, ILocationBL locationBL, IProductBL productBL, IOrderBL orderBL)
        {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _orderBL = orderBL;
            _mapper = mapper;
        }
        // GET: ManagerController - Goes to the manager main menu
        public ActionResult Index()
        {
            return View();
        }
        //Inventory History: Display locations
        public ActionResult ViewLocations()
        {
            return View(_locationBL.GetLocations());
        }
        //Sort option for order history per location
        public ActionResult StoreOrderHistory(int locationID)
        {
            ViewBag.Location = locationID;
            Location location = _locationBL.GetSpecificLocation(locationID);
            ViewBag.LocationName = location.LocationName;
            return View();
        }
        //Display order history based on sort selection
        public ActionResult DisplayStoreOrderHistory(string sortby, int locationID)
        {
            Location location = _locationBL.GetSpecificLocation(locationID);
            List<Order> orders = null;
            if (sortby == "ASCDate")
            {
                orders = _orderBL.GetLocationOrderASC(locationID);
            }
            else if (sortby == "DESCDate")
            {
                orders = _orderBL.GetLocationOrderDESC(locationID);
            }
            else if (sortby == "ASCTotal")
            {
                orders = _orderBL.GetLocationOrderASCTotal(locationID);
            }
            else if (sortby == "DESCTotal")
            {
                orders = _orderBL.GetLocationOrderDESCTotal(locationID);
            }
            if (orders.Count < 1)
            {
                return View("~/Views/Customer/OrderHistoryEmpty.cshtml");
            }
            else
            {
                ViewBag.Location = locationID;
                ViewBag.LocationName = location.LocationName;
                ViewBag.Orders = orders;
                return View();
            }
        }
        //Display products for an order (based on location sorting)
        public ActionResult ViewProductsForOrder(int orderID)
        {
            List<ProductOrder> productOrders = _orderBL.GetProductsByOrderID(orderID);
            ViewBag.Products = productOrders;
            return View();
        }
        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
