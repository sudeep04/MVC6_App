using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVC6_App.Models;

namespace MVC6_App.Controllers
{
    public class HomeController : Controller
    {
        private MVC6_AppDbContext _context;

        public HomeController(MVC6_AppDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Index()
        {
            var mVC6_AppDbContext = _context.User.Include(u => u.Customers);
            return View(mVC6_AppDbContext.ToList());
        }


    }
       
}
