using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using entityStore.Models;
using System.Linq;

namespace entityStore.Controllers
{
    public class CustomerController : Controller
    {
        private StoreContext _context;
        public CustomerController(StoreContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("customers")]
        public IActionResult Index()
        {
            ViewBag.Customers = _context.Customers.OrderByDescending(c => c.CreatedAt);
            return View("CustomersIndex");
        }
        [HttpPost]
        [Route("customers")]
        public IActionResult CreateCustomer(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                Customer NewCustomer = new Customer {
                    Name = customer.Name,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Customers.Add(NewCustomer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = _context.Customers.OrderByDescending(c => c.CreatedAt);
            return View("CustomersIndex");
        }
    }
}
