using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using entityStore.Models;
using System.Linq;

namespace entityStore.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            ViewBag.Products = _context.Products.OrderByDescending(c => c.CreatedAt);
            return View("ProductsIndex");
        }
        [HttpPost]
        [Route("products")]
        public IActionResult AddProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                Product NewProduct = new Product {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Url = product.Url,
                    Quantity = product.Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Products.Add(NewProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Products = _context.Products.OrderByDescending(c => c.CreatedAt);
            return View("ProductsIndex");
        }
    }
}
