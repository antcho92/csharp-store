using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using entityStore.Models;
using System.Linq;

namespace entityStore.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext _context;
        public HomeController(StoreContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Orders = _context.Orders.OrderBy(o => o.CreatedAt).ToList().Take(3);;
            ViewBag.Customers = _context.Customers.OrderByDescending(c => c.CreatedAt).ToList().Take(5);
            ViewBag.Products = _context.Products.OrderByDescending(p => p.Quantity).ToList().Take(6);
            return View();
        }
    }
}
