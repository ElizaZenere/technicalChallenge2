using Microsoft.Ajax.Utilities;
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
    public class SubscriptionsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Subscriptions
        public List<DataSubscriptions> GetSubscriptions()
        {
            List<DataSubscriptions> DataSubscriptions = new List<DataSubscriptions>();
            foreach (Subscriptions Sub in db.Subscriptions)
            {
                DataSubscriptions DataSubscription = new DataSubscriptions();
                DataSubscription.idSubscription = Sub.idSubscription;
                DataSubscription.interval = (decimal)Sub.interval;
                DataSubscription.nextDonation = (DateTime)Sub.nextDonation;
                DataSubscription.numberCard = (decimal)Sub.numberCard;
                DataSubscription.paymentMethod = (decimal)Sub.paymentMethod;
                DataSubscription.amount = (decimal)Sub.amount;
                List<Donations> Donations = db.Donations.Where(e => e.idSubscription == (decimal) Sub.idSubscription).OrderBy(e => e.dateDonation).ToList();
                bool ban = true;
                decimal plus = 0;
                foreach (Donations Don in Donations)
                {
                    if (ban) {
                        ban=false;
                        DataSubscription.sinceDonation = (DateTime) Don.dateDonation;
                    }
                    plus += Don.amount;
                }
                DataSubscription.totalDonation = plus;

                DataSubscriptions.Add(DataSubscription);

            }
            return DataSubscriptions;
        }

        // GET: api/Subscriptions/5
        [ResponseType(typeof(Subscriptions))]
        public IHttpActionResult GetSubscriptions(decimal id)
        {
            Subscriptions subscriptions = db.Subscriptions.Find(id);
            if (subscriptions == null)
            {
                return NotFound();
            }

            return Ok(subscriptions);
        }

        // PUT: api/Subscriptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubscriptions(decimal id, Subscriptions subscriptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriptions.idSubscription)
            {
                return BadRequest();
            }

            if (subscriptions.nextDonation?.Date == DateTime.Today.Date &&
                subscriptions.nextDonation?.Month == DateTime.Today.Month &&
                subscriptions.nextDonation?.Year == DateTime.Today.Year)
            {
                DateTime today = DateTime.Today;
                DateTime tomorrow = today.AddDays(1);

                Donations donations = db.Donations.Where(e => e.dateDonation >= today)
                    .Where(e => e.dateDonation < tomorrow)
                    .Where(e => e.idSubscription == subscriptions.idSubscription).FirstOrDefault();
                if (donations == null)
                {
                    Donations donation = new Donations();

                    donation.dateDonation = DateTime.Today;
                    donation.idSubscription = subscriptions.idSubscription;
                    donation.amount = (decimal)subscriptions.amount;

                    db.Donations.Add(donation);
                    db.SaveChanges();
                    
                }
                Intervals intervals = db.Intervals.Find(id);

                subscriptions.nextDonation = DateTime.Today.AddMonths((int)intervals.months);
            
            }
           
            
            db.Entry(subscriptions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionsExists(id))
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

        // POST: api/Subscriptions
        [ResponseType(typeof(Subscriptions))]
        public IHttpActionResult PostSubscriptions(Subscriptions subscriptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscriptions.Add(subscriptions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subscriptions.idSubscription }, subscriptions);
        }

        // DELETE: api/Subscriptions/5
        [ResponseType(typeof(Subscriptions))]
        public IHttpActionResult DeleteSubscriptions(decimal id)
        {
            Subscriptions subscriptions = db.Subscriptions.Find(id);
            if (subscriptions == null)
            {
                return NotFound();
            }

            db.Subscriptions.Remove(subscriptions);
            db.SaveChanges();

            return Ok(subscriptions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriptionsExists(decimal id)
        {
            return db.Subscriptions.Count(e => e.idSubscription == id) > 0;
        }
    }
}