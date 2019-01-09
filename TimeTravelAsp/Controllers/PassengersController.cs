using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeTravelAsp.Models;

namespace TimeTravelAsp.Controllers
{
    public class PassengersController : Controller
    {
        private readonly TimeTravelAspContext db = new TimeTravelAspContext();

        // GET: Passengers
        public async Task<ActionResult> Index()
        {
            var passengers = db.Passengers.Include(p => p.Transporter);
            return View(await passengers.ToListAsync());
        }

        // GET: Passengers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var passenger = await db.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            await db.Entry(passenger).Reference("Transporter").LoadAsync();    
            return View(passenger);
        }

        // GET: Passengers/Create
        public ActionResult Create()
        {
            ViewBag.TransporterId = new SelectList(db.Transporters, "Id", "Name");
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,PositionInTime,Destination,TransporterId")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.Passengers.Add(passenger);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TransporterId = new SelectList(db.Transporters, "Id", "Name", passenger.TransporterId);
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransporterId = new SelectList(db.Transporters, "Id", "Name", passenger.TransporterId);
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,PositionInTime,Destination,TransporterId")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passenger).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TransporterId = new SelectList(db.Transporters, "Id", "Name", passenger.TransporterId);
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Passenger passenger = await db.Passengers.FindAsync(id);
            db.Passengers.Remove(passenger);
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
