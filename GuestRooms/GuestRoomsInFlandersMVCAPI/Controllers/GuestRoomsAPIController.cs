using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KamersInVlaanderen;
using KamersInVlaanderenDomain.DataModel;

namespace GuestRoomsInFlandersMVCAPI.Controllers
{
    public class GuestRoomsAPIController : ApiController
    {
        private KamersContext db = new KamersContext();

        // GET: api/GuestRoomsAPI
        public IQueryable<GuestRoom> GetGuestRooms()
        {
            var test = db.GuestRooms.Include(g => g.Address).Include(g => g.Location).Include(g => g.ImageURLs).Include(g => g.Ratings);
            /*foreach(var t in test)
            {
                var images = db.ImageURLs.Where(x => x.GuestRoomId == t.Id);
                foreach (var image in images)
                {
                    t.ImageURLs.Add(image);
                }
            }*/
            return test;
        }

        // GET: api/GuestRoomsAPI/5
        [ResponseType(typeof(GuestRoom))]
        public IHttpActionResult GetGuestRoom(int id)
        {
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            if (guestRoom == null)
            {
                return NotFound();
            }

            return Ok(guestRoom);
        }

        // PUT: api/GuestRoomsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuestRoom(int id, GuestRoom guestRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guestRoom.Id)
            {
                return BadRequest();
            }

            db.Entry(guestRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GuestRoomsAPI
        [ResponseType(typeof(GuestRoom))]
        public IHttpActionResult PostGuestRoom(GuestRoom guestRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GuestRooms.Add(guestRoom);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = guestRoom.Id }, guestRoom);
        }

        // DELETE: api/GuestRoomsAPI/5
        [ResponseType(typeof(GuestRoom))]
        public IHttpActionResult DeleteGuestRoom(int id)
        {
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            if (guestRoom == null)
            {
                return NotFound();
            }

            db.GuestRooms.Remove(guestRoom);
            db.SaveChanges();

            return Ok(guestRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestRoomExists(int id)
        {
            return db.GuestRooms.Count(e => e.Id == id) > 0;
        }
    }
}