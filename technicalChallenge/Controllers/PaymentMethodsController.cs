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
    public class PaymentMethodsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PaymentMethods
        public IQueryable<PaymentMethods> GetPaymentMethods()
        {
            return db.PaymentMethods;
        }

        // GET: api/PaymentMethods/5
        [ResponseType(typeof(PaymentMethods))]
        public IHttpActionResult GetPaymentMethods(decimal id)
        {
            PaymentMethods paymentMethods = db.PaymentMethods.Find(id);
            if (paymentMethods == null)
            {
                return NotFound();
            }

            return Ok(paymentMethods);
        }

        // PUT: api/PaymentMethods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentMethods(decimal id, PaymentMethods paymentMethods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentMethods.idPaymentMethod)
            {
                return BadRequest();
            }

            db.Entry(paymentMethods).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodsExists(id))
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

        // POST: api/PaymentMethods
        [ResponseType(typeof(PaymentMethods))]
        public IHttpActionResult PostPaymentMethods(PaymentMethods paymentMethods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentMethods.Add(paymentMethods);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paymentMethods.idPaymentMethod }, paymentMethods);
        }

        // DELETE: api/PaymentMethods/5
        [ResponseType(typeof(PaymentMethods))]
        public IHttpActionResult DeletePaymentMethods(decimal id)
        {
            PaymentMethods paymentMethods = db.PaymentMethods.Find(id);
            if (paymentMethods == null)
            {
                return NotFound();
            }

            db.PaymentMethods.Remove(paymentMethods);
            db.SaveChanges();

            return Ok(paymentMethods);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentMethodsExists(decimal id)
        {
            return db.PaymentMethods.Count(e => e.idPaymentMethod == id) > 0;
        }
    }
}