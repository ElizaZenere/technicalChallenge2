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
using technicalChallenge;
using technicalChallenge.Models;

namespace technicalChallenge.Controllers
{
    public class DonationsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Donations
        public IQueryable<Donations> GetDonations()
        {
            return db.Donations;
        }

        // GET: api/Donations/5
        [ResponseType(typeof(Donations))]
        public IHttpActionResult GetDonations(decimal id)
        {
            Donations donations = db.Donations.Find(id);
            if (donations == null)
            {
                return NotFound();
            }

            return Ok(donations);
        }

        // PUT: api/Donations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonations(decimal id, Donations donations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donations.idDonation)
            {
                return BadRequest();
            }

            db.Entry(donations).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationsExists(id))
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

        // POST: api/Donations
        [ResponseType(typeof(Donations))]
        public IHttpActionResult PostDonations(Donations donations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donations.Add(donations);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donations.idDonation }, donations);
        }

        // DELETE: api/Donations/5
        [ResponseType(typeof(Donations))]
        public IHttpActionResult DeleteDonations(decimal id)
        {
            Donations donations = db.Donations.Find(id);
            if (donations == null)
            {
                return NotFound();
            }

            db.Donations.Remove(donations);
            db.SaveChanges();

            return Ok(donations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonationsExists(decimal id)
        {
            return db.Donations.Count(e => e.idDonation == id) > 0;
        }
    }
}