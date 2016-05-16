using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVC6_App.Models;

namespace MVC6_App.Controllers
{
    public class UsersController : Controller
    {
        private MVC6_AppDbContext _context;

        public UsersController(MVC6_AppDbContext context)
        {
            _context = context;    
        }

        // GET: Users
        public IActionResult Index()
        {
            var mVC6_AppDbContext = _context.User.Include(u => u.Customers);
            return View(mVC6_AppDbContext.ToList());
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            User user = _context.User.Single(m => m.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Customers");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Customers", user.CustomerId);
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            User user = _context.User.Single(m => m.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Customers", user.CustomerId);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Customers", user.CustomerId);
            return View(user);
        }

        // GET: Users/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            User user = _context.User.Single(m => m.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            User user = _context.User.Single(m => m.UserId == id);
            _context.User.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
