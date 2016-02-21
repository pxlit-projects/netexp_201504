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
    public class ImageURLsAPIController : ApiController
    {
        private KamersContext db = new KamersContext();

        // GET: api/ImageURLsAPI
        public IQueryable<ImageURL> GetImageURLs()
        {
            return db.ImageURLs;
        }

        // GET: api/ImageURLsAPI/5
        [ResponseType(typeof(ImageURL))]
        public IHttpActionResult GetImageURL(int id)
        {
            ImageURL imageURL = db.ImageURLs.Find(id);
            if (imageURL == null)
            {
                return NotFound();
            }

            return Ok(imageURL);
        }

        // PUT: api/ImageURLsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImageURL(int id, ImageURL imageURL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageURL.Id)
            {
                return BadRequest();
            }

            db.Entry(imageURL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageURLExists(id))
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

        // POST: api/ImageURLsAPI
        [ResponseType(typeof(ImageURL))]
        public IHttpActionResult PostImageURL(ImageURL imageURL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImageURLs.Add(imageURL);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imageURL.Id }, imageURL);
        }

        // DELETE: api/ImageURLsAPI/5
        [ResponseType(typeof(ImageURL))]
        public IHttpActionResult DeleteImageURL(int id)
        {
            ImageURL imageURL = db.ImageURLs.Find(id);
            if (imageURL == null)
            {
                return NotFound();
            }

            db.ImageURLs.Remove(imageURL);
            db.SaveChanges();

            return Ok(imageURL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageURLExists(int id)
        {
            return db.ImageURLs.Count(e => e.Id == id) > 0;
        }
    }
}