using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreBL;
using StoreModels;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoreMVC.Controllers
{
    /// <summary>
    /// Controller to respond to shopping requests by the client and server
    /// </summary>
    public class ShopController : Controller
    {
        private ILocationBL _locationBL;
        private IItemBL _itemBL;
        private IProductBL _productBL;
        private ICustomerBL _customerBL;
        private IOrderBL _orderBL;
        private IProductOrderBL _productOrderBL;
        private IMapper _mapper;
        public ShopController(ILocationBL locationBL, IMapper mapper, IItemBL itemBL, IProductBL productBL, ICustomerBL customerBL, IOrderBL orderBL, IProductOrderBL productOrderBL)
        {
            _locationBL = locationBL;
            _mapper = mapper;
            _itemBL = itemBL;
            _productBL = productBL;
            _customerBL = customerBL;
            _orderBL = orderBL;
            _productOrderBL = productOrderBL;
        }
        // GET: ShopController
        public ActionResult Index()
        {
            return View(_locationBL.GetLocations().Select(location => _mapper.Cast2LocationIndexVM(location)).ToList());
        }
        public ActionResult Shop(int locationID)
        {
            List<SelectListItem> Q = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text="1", Value = "1"
                },
                 new SelectListItem
                {
                    Text="2", Value = "2"
                },
                  new SelectListItem
                {
                    Text="3", Value = "3"
                },
            };
            ViewBag.Q = Q;
            return View(_itemBL.GetItemsByLocation(locationID).Select(item => _mapper.Cast2ItemCRVM(item)).ToList());
        }
        //SET: Set the quantity of the selected product
        public ActionResult Quantity(int productID, int locationID)
        {
            LocationCRVM location = _mapper.Cast2LocationCRVM(_locationBL.GetSpecificLocation(locationID));
            ProductCRVM product = _mapper.Cast2ProductCRVM(_productBL.GetProductByID(productID));
            ViewBag.SelectedProduct = product;
            ViewBag.SelectedLocation = location;
            return View();
        }
        //SET: Add the selected product and desired quantity to the cart (a.k.a our storedProductsQuantity object)
        public ActionResult AddToCart(string selectedLocation, string selectedProduct, int selectedQuantity)
        {
            ProductCRVM p = _mapper.Cast2ProductCRVM(_productBL.GetProductByName(selectedProduct));
            StoredProductsQuantity cart = new StoredProductsQuantity();
            cart.Product2BeBought = p;
            cart.Quantity2BeBought = selectedQuantity;
            StoredProductsQuantity.storedProductsQuantity.Add(cart);
            //Return back to store products view
            int locationID = _locationBL.GetLocationByName(selectedLocation).LocationID;
            ViewBag.LocationID = locationID;
            return View(_itemBL.GetItemsByLocation(locationID).Select(item => _mapper.Cast2ItemCRVM(item)).ToList());
        }
        //Set/GET: Review products in order and finally place order 
        public ActionResult ReviewOrder(int locationID)
        {
            double total = 0.0;
            foreach(var item in StoredProductsQuantity.storedProductsQuantity)
            {
                total += (item.Product2BeBought.Price * item.Quantity2BeBought);
            }
            List<CustomerShopModel> custListShop = new List<CustomerShopModel>();
            List<Customer> custList = _customerBL.GetCustomers().Select(cust => (cust)).ToList();
            foreach(var item in custList)
            {
                custListShop.Add(_mapper.Cast2CustomerShopModel(item));
            }
            ViewBag.Total = total;
            ViewBag.Customers = custListShop;
            ViewBag.LocationID = locationID;
            return View();
        }
        //Create new Order Object, view products from cart and order total
        public ActionResult FinalizeOrder(int locationID, int custID, double total)
        {
            Customer customer = _customerBL.GetCustomerByID(custID);
            Location location = _locationBL.GetSpecificLocation(locationID);
            OrderCRVM order = new OrderCRVM();
            order.Date = DateTime.Now;
            order.Customer = customer;
            order.Location = location;
            order.Total = total;
            //_orderBL.AddOrder(_mapper.Cast2Order(order));
            ViewBag.ProductQuantity = StoredProductsQuantity.storedProductsQuantity;
            return View();
        }
        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
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

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopController/Edit/5
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

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
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
