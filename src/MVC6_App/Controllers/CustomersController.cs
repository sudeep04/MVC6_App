using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MVC6_App.Models;

namespace MVC6_App.Controllers
{
    public class CustomersController : Controller
    {
        private MVC6_AppDbContext _context;

        public CustomersController(MVC6_AppDbContext context)
        {
            _context = context;    
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View(_context.Customers.ToList());
        }

        // GET: Customers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customers customers = _context.Customers.Single(m => m.CustomerId == id);
            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customers customers = _context.Customers.Single(m => m.CustomerId == id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Update(customers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Customers customers = _context.Customers.Single(m => m.CustomerId == id);
            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Customers customers = _context.Customers.Single(m => m.CustomerId == id);
            _context.Customers.Remove(customers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
