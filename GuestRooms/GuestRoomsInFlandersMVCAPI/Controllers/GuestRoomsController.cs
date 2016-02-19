using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KamersInVlaanderen;
using KamersInVlaanderenDomain.DataModel;

namespace GuestRoomsInFlandersMVCAPI.Controllers
{
    public class GuestRoomsController : Controller
    {
        private KamersContext db = new KamersContext();

        // GET: GuestRooms
        public ActionResult Index()
        {
            var guestRooms = db.GuestRooms.Include(g => g.Address).Include(g => g.Location);
            return View(guestRooms.ToList());
        }

        // GET: GuestRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            if (guestRoom == null)
            {
                return HttpNotFound();
            }
            return View(guestRoom);
        }

        // GET: GuestRooms/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Id");
            return View();
        }

        // POST: GuestRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BusinessProductGroupId,BusinessProductId,Name,AddressId,LocationId,Phone,Mobile,Email,Website")] GuestRoom guestRoom)
        {
            if (ModelState.IsValid)
            {
                db.GuestRooms.Add(guestRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street", guestRoom.AddressId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Id", guestRoom.LocationId);
            return View(guestRoom);
        }

        // GET: GuestRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            if (guestRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street", guestRoom.AddressId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Id", guestRoom.LocationId);
            return View(guestRoom);
        }

        // POST: GuestRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BusinessProductGroupId,BusinessProductId,Name,AddressId,LocationId,Phone,Mobile,Email,Website")] GuestRoom guestRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Street", guestRoom.AddressId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Id", guestRoom.LocationId);
            return View(guestRoom);
        }

        // GET: GuestRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            if (guestRoom == null)
            {
                return HttpNotFound();
            }
            return View(guestRoom);
        }

        // POST: GuestRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            db.GuestRooms.Remove(guestRoom);
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
