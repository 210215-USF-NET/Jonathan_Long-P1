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
        private IMapper _mapper;
        public CustomerController(ICustomerBL customerBL, IMapper mapper)
        {
            _customerBL = customerBL;
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
        /// <summary>
        /// Action that sends client to view to search for a customer
        /// </summary>
        public ActionResult SerachCustomer()
        {
            try
            {
                return View();
            }
            catch
            {
                
                return View();
            }
        }
        

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
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
