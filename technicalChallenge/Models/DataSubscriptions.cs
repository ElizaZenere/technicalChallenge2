using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace technicalChallenge.Models
{
    public class DataSubscriptions
    {
        public decimal idSubscription { get; set; }
        public decimal amount { get; set; }
        public decimal interval { get; set; }
        public DateTime nextDonation { get; set; }
        public decimal paymentMethod { get; set; }
        public decimal numberCard { get; set; }
        public decimal totalDonation { get; set; }
        public DateTime sinceDonation { get; set; }

    }
}