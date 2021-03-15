using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Controllers
{
    /// <summary>
    /// Controller for customers
    /// </summary>
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IOrderBL _orderBL;
        private IMapper _mapper;
        public CustomerController(ICustomerBL customerBL, IMapper mapper, ILocationBL locationBL, IProductBL productBL, IOrderBL orderBL)
        {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _orderBL = orderBL;
            _mapper = mapper;
        }
        // GET: CustomerController
        public ActionResult Index(string search)
        {
            if(search != null)
            {
                List<Customer> custList = _customerBL.GetCustomers().Select(cust => (cust)).ToList();
                foreach(var item in custList )
                {
                    if(item.FirstName.ToString() == search)
                    {
                        List<CustomerIndexVM> l1 = new List<CustomerIndexVM>();
                        l1.Add(_mapper.Cast2CustomerIndexVM(item));
                        return View(l1);
                    }
                    else if(search.Contains(' '))
                    {
                        var words = search.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if(item.FirstName.ToString() == words[0] && item.LastName.ToString() == words[1])
                        {
                            List<CustomerIndexVM> l1 = new List<CustomerIndexVM>();
                            l1.Add(_mapper.Cast2CustomerIndexVM(item));
                            return View(l1);
                        }
                    }
                }
            }
            return View(_customerBL.GetCustomers().Select(cust => _mapper.Cast2CustomerIndexVM(cust)).ToList());
        }
        // GET: CustomerController/Details/{cust firstName, cust lastName}
        public ActionResult Details(string firstName, string lastName)
        {
            return View(_mapper.Cast2CustomerCRVM(_customerBL.GetCustomerByName(firstName, lastName)));
        }
        //View Customer Order History
        public ActionResult OrderHistory(string firstName, string lastName)
        {
            int custID = _customerBL.GetCustomerByName(firstName, lastName).CustID;
            string custName = firstName + " " + lastName;
            ViewBag.CustName = custName;
            ViewBag.CustFirstName = firstName;
            ViewBag.CustLastName = lastName;
            return View();
        }
        //View Customer Order history based on sort selection 
        [ActionName("OrderHistorySort")]
        public ActionResult OrderHistory(string firstName, string lastName, string sortby)
        {
            int custID = _customerBL.GetCustomerByName(firstName, lastName).CustID;
            List<Order> orders = null;
            if (sortby == "ASCDate")
            {
                orders = _orderBL.GetCustomerOrdersASC(custID);
            }
            else if(sortby == "DESCDate")
            {
                orders = _orderBL.GetCustomerOrdersDESC(custID);
            }
            else if (sortby == "ASCTotal")
            {
                orders = _orderBL.GetCustomerOrdersASCTotal(custID);
            }
            else if (sortby == "DESCTotal")
            {
                orders = _orderBL.GetCustomerOrdersDESCTotal(custID);
            }
            if(orders.Count <1)
            {
                return View("~/Views/Customer/OrderHistoryEmpty.cshtml");
            }
            else
            {
                ViewBag.CustFirstName = firstName;
                ViewBag.CustLastName = lastName;
                ViewBag.Orders = orders;
                return View();
            }
        }
        //Display products for a particular customer order
        public ActionResult ViewProductsForOrder(int orderID)
        {
            List<ProductOrder> productOrders = _orderBL.GetProductsByOrderID(orderID);
            ViewBag.Products = productOrders;
            return View();
        }
        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCRVM newCustomer)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _customerBL.AddCustomer(_mapper.Cast2Customer(newCustomer));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
           
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
