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
    public class IntervalsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Intervals
        public IQueryable<Intervals> GetIntervals()
        {
            return db.Intervals;
        }

        // GET: api/Intervals/5
        [ResponseType(typeof(Intervals))]
        public IHttpActionResult GetIntervals(decimal id)
        {
            Intervals intervals = db.Intervals.Find(id);
            if (intervals == null)
            {
                return NotFound();
            }

            return Ok(intervals);
        }

        // PUT: api/Intervals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIntervals(decimal id, Intervals intervals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intervals.idInterval)
            {
                return BadRequest();
            }

            db.Entry(intervals).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntervalsExists(id))
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

        // POST: api/Intervals
        [ResponseType(typeof(Intervals))]
        public IHttpActionResult PostIntervals(Intervals intervals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Intervals.Add(intervals);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = intervals.idInterval }, intervals);
        }

        // DELETE: api/Intervals/5
        [ResponseType(typeof(Intervals))]
        public IHttpActionResult DeleteIntervals(decimal id)
        {
            Intervals intervals = db.Intervals.Find(id);
            if (intervals == null)
            {
                return NotFound();
            }

            db.Intervals.Remove(intervals);
            db.SaveChanges();

            return Ok(intervals);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntervalsExists(decimal id)
        {
            return db.Intervals.Count(e => e.idInterval == id) > 0;
        }
    }
}