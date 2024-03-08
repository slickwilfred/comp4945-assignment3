using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Views
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            var people = db.People.Include(c => c.Address).Include(c => c.Name);
            return View(await people.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.FullAddresses, "PersonID", "Street");
            ViewBag.ID = new SelectList(db.FullNames, "PersonID", "FirstName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.FullAddresses, "PersonID", "Street", customer.ID);
            ViewBag.ID = new SelectList(db.FullNames, "PersonID", "FirstName", customer.ID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.FullAddresses, "PersonID", "Street", customer.ID);
            ViewBag.ID = new SelectList(db.FullNames, "PersonID", "FirstName", customer.ID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.FullAddresses, "PersonID", "Street", customer.ID);
            ViewBag.ID = new SelectList(db.FullNames, "PersonID", "FirstName", customer.ID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customer customer = (Customer) db.People.Find(id);
            db.People.Remove(customer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
