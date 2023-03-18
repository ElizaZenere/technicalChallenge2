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
    public class ViewSubscriptionsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ViewSubscriptions
        public IQueryable<ViewSubscriptions> GetViewSubscriptions()
        {
            return db.ViewSubscriptions;
        }

        // GET: api/ViewSubscriptions/5
        [ResponseType(typeof(ViewSubscriptions))]
        public IHttpActionResult GetViewSubscriptions(decimal id)
        {
            ViewSubscriptions viewSubscriptions = db.ViewSubscriptions.Find(id);
            if (viewSubscriptions == null)
            {
                return NotFound();
            }

            return Ok(viewSubscriptions);
        }

        // PUT: api/ViewSubscriptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViewSubscriptions(decimal id, ViewSubscriptions viewSubscriptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewSubscriptions.idSubscriptor)
            {
                return BadRequest();
            }

            db.Entry(viewSubscriptions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewSubscriptionsExists(id))
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

        // POST: api/ViewSubscriptions
        [ResponseType(typeof(ViewSubscriptions))]
        public IHttpActionResult PostViewSubscriptions(ViewSubscriptions viewSubscriptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViewSubscriptions.Add(viewSubscriptions);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ViewSubscriptionsExists(viewSubscriptions.idSubscriptor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = viewSubscriptions.idSubscriptor }, viewSubscriptions);
        }

        // DELETE: api/ViewSubscriptions/5
        [ResponseType(typeof(ViewSubscriptions))]
        public IHttpActionResult DeleteViewSubscriptions(decimal id)
        {
            ViewSubscriptions viewSubscriptions = db.ViewSubscriptions.Find(id);
            if (viewSubscriptions == null)
            {
                return NotFound();
            }

            db.ViewSubscriptions.Remove(viewSubscriptions);
            db.SaveChanges();

            return Ok(viewSubscriptions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViewSubscriptionsExists(decimal id)
        {
            return db.ViewSubscriptions.Count(e => e.idSubscriptor == id) > 0;
        }
    }
}