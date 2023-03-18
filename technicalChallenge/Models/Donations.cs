namespace technicalChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donations
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal idDonation { get; set; }


        [Column(Order = 1, TypeName = "numeric")]
        public decimal idSubscriptor { get; set; }


        [Column(Order = 2, TypeName = "numeric")]
        public decimal amount { get; set; }


        [Column(Order = 3)]
        public DateTime dateDonation { get; set; }
    }
}
