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
            return View();
        }
    }
}
