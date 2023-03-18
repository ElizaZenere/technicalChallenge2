namespace technicalChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscriptions
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal idSubscriptor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? interval { get; set; }

        [Column(TypeName = "date")]
        public DateTime? nextDonation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? paymentMethod { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? numberCard { get; set; }
    }
}
