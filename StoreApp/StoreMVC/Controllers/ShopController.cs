using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private IMapper _mapper;
        public ShopController(ILocationBL locationBL, IMapper mapper, IItemBL itemBL, IProductBL productBL)
        {
            _locationBL = locationBL;
            _mapper = mapper;
            _itemBL = itemBL;
            _productBL = productBL;
        }
        // GET: ShopController
        public ActionResult Index()
        {
            return View(_locationBL.GetLocations().Select(location => _mapper.Cast2LocationIndexVM(location)).ToList());
        }
        public ActionResult Shop(int locationID)
        {
            return View(_itemBL.GetItemsByLocation(locationID).Select(item => _mapper.Cast2ItemCRVM(item)).ToList());
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
