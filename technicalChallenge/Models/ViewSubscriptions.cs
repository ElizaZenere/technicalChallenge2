namespace technicalChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ViewSubscriptions
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal idSubscriptor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? interval { get; set; }

        [Column(TypeName = "date")]
        public DateTime? nextDonation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? paymentMethod { get; set; }

        [StringLength(4)]
        public string numberCard { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalDonation { get; set; }

        public DateTime? sinceDonation { get; set; }
    }
}
