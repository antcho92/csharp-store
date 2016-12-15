using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using entityStore.Models;
using System.Linq;

namespace entityStore.Controllers
{
    public class OrderController : Controller
    {
        private StoreContext _context;
        public OrderController(StoreContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("orders")]
        public IActionResult Index()
        {
            ViewBag.Orders = _context.Orders;
            ViewBag.Products = _context.Products.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View("OrderIndex");
        }
        [HttpPost]
        [Route("orders")]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                Order NewOrder = new Order {

                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Orders.Add(NewOrder);
                // _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = _context.Orders;
            return View("OrderIndex");
        }
    }
}
