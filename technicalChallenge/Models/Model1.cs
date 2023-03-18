using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using technicalChallenge.Models;

namespace technicalChallenge
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Donations> Donations { get; set; }
        public virtual DbSet<Intervals> Intervals { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<ViewSubscriptions> ViewSubscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donations>()
                .Property(e => e.idDonation)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donations>()
                .Property(e => e.idSubscriptor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donations>()
                .Property(e => e.amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Intervals>()
                .Property(e => e.idInterval)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Intervals>()
                .Property(e => e.intervalName)
                .IsFixedLength();

            modelBuilder.Entity<PaymentMethods>()
                .Property(e => e.idPaymentMethod)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PaymentMethods>()
                .Property(e => e.PaymentMethodName)
                .IsFixedLength();

            modelBuilder.Entity<Subscriptions>()
                .Property(e => e.idSubscriptor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Subscriptions>()
                .Property(e => e.amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Subscriptions>()
                .Property(e => e.interval)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Subscriptions>()
                .Property(e => e.paymentMethod)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Subscriptions>()
                .Property(e => e.numberCard)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ViewSubscriptions>()
                .Property(e => e.idSubscriptor)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ViewSubscriptions>()
                .Property(e => e.amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ViewSubscriptions>()
                .Property(e => e.interval)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ViewSubscriptions>()
                .Property(e => e.paymentMethod)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ViewSubscriptions>()
                .Property(e => e.TotalDonation)
                .HasPrecision(38, 0);
        }
       
    }
}
