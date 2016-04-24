using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BC_Rentals.DAL;
using BC_Rentals.Models;

namespace BC_Rentals.Controllers
{
    public class RentalController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: Rental
        public ActionResult Index()
        {
            var rental = db.Rental.Include(r => r.Customer).Include(r => r.Vehicle);
            return View(rental.ToList());
        }

        // GET: Rental/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rental/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "CustomerDetails");
            ViewBag.Vehicle_ID = new SelectList(db.Vehicle, "Vehicle_ID", "VehicleDetails");
            return View();
        }

        // POST: Rental/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rental_ID,Customer_ID,Vehicle_ID,Rental_Start,Rental_End")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rental.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "CustomerDetails", rental.Customer_ID);
            ViewBag.Vehicle_ID = new SelectList(db.Vehicle, "Vehicle_ID", "VehicleDetails", rental.Vehicle_ID);
            return View(rental);
        }

        // GET: Rental/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "First_Name", rental.Customer_ID);
            ViewBag.Vehicle_ID = new SelectList(db.Vehicle, "Vehicle_ID", "Vehicle_Manuf", rental.Vehicle_ID);
            return View(rental);
        }

        // POST: Rental/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rental_ID,Customer_ID,Vehicle_ID,Rental_Start,Rental_End")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "First_Name", rental.Customer_ID);
            ViewBag.Vehicle_ID = new SelectList(db.Vehicle, "Vehicle_ID", "Vehicle_Manuf", rental.Vehicle_ID);
            return View(rental);
        }

        // GET: Rental/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rental.Find(id);
            db.Rental.Remove(rental);
            db.SaveChanges();
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
