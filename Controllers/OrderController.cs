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
            ViewBag.Products = _context.Products.OrderByDescending(p => p.Quantity).ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View("OrderIndex");
        }
        [HttpPost]
        [Route("orders")]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                Product checkProduct = _context.Products.SingleOrDefault(p => p.ProductId == order.ProductId);
                if(checkProduct.Quantity >= order.Quantity && order.Quantity > 0)
                {
                    Order NewOrder = new Order {
                        ProductId = order.ProductId,
                        CustomerId = order.CustomerId,
                        Quantity = order.Quantity,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    checkProduct.Quantity -= NewOrder.Quantity;
                    _context.Orders.Add(NewOrder);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    // Custom ModelState error message
                    ModelState.AddModelError(string.Empty, "Invalid Quantity");
                }
            }
            System.Console.WriteLine("Failed to add order");
            ViewBag.Products = _context.Products.OrderByDescending(p => p.Quantity).ToList();
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Orders = _context.Orders;
            return View("OrderIndex");
        }
    }
}
