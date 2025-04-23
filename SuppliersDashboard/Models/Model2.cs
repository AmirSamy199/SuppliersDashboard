using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SuppliersDashboard.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<Bill_Detiles_Tbl> Bill_Detiles_Tbl { get; set; }
        public virtual DbSet<Bill_Tbl> Bill_Tbl { get; set; }
        public virtual DbSet<Branch_tbl> Branch_tbl { get; set; }
        public virtual DbSet<ETA_Bill_Detiles_Tbl> ETA_Bill_Detiles_Tbl { get; set; }
        public virtual DbSet<ETA_Bill_Tax_Tbl> ETA_Bill_Tax_Tbl { get; set; }
        public virtual DbSet<ETA_Bill_Tbl> ETA_Bill_Tbl { get; set; }
        public virtual DbSet<Items_Tbl> Items_Tbl { get; set; }
        public virtual DbSet<Items_tbl1> Items_tbl1 { get; set; }
        public virtual DbSet<VAT_tbl1> VAT_tbl1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill_Detiles_Tbl>()
                .Property(e => e.NumberOfUnits)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Detiles_Tbl>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Detiles_Tbl>()
                .Property(e => e.TotalPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Detiles_Tbl>()
                .Property(e => e.size)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Detiles_Tbl>()
                .Property(e => e.Discount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Detiles_Tbl>()
                .Property(e => e.Supply_Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Detiles_Tbl>()
                .Property(e => e.discountItemSize)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.Discount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.WTHOLDINGTAX)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.VAT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.TotalAmountBeforDiscount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.TotalAmountAfterDiscount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.TotalAmountAfterVAT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.VAT_Prs)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.Cash)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.Deferred)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.ReturnAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.CollectionAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.Longitude)
                .HasPrecision(18, 14);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.Latitude)
                .HasPrecision(18, 14);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.DistanceInMeters)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill_Tbl>()
                .Property(e => e.BillCash)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Branch_tbl>()
                .Property(e => e.Longitude)
                .HasPrecision(18, 14);

            modelBuilder.Entity<Branch_tbl>()
                .Property(e => e.Latitude)
                .HasPrecision(18, 14);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.NumberOfUnits)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.ItemDiscount_rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.ItemDiscount_amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.currencyExchangeRate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.SubmittionUUID)
                .IsUnicode(false);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.GrossTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Detiles_Tbl>()
                .Property(e => e.Vat)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tax_Tbl>()
                .Property(e => e.TAX_Rate)
                .IsFixedLength();

            modelBuilder.Entity<ETA_Bill_Tax_Tbl>()
                .Property(e => e.TaxAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.Discount_Amt)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.Discount_Rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.WTHOLDINGTAX)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.WTHOLDINGTAX_Rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.VAT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.TotalAmountBeforDiscount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.TotalAmountAfterDiscount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.TotalAmountAfterVAT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.VAT_Prs)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ETA_Bill_Tbl>()
                .Property(e => e.currencyExchangeRate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Items_Tbl>()
                .Property(e => e.size)
                .HasPrecision(10, 3);

            modelBuilder.Entity<VAT_tbl1>()
                .Property(e => e.VAT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<VAT_tbl1>()
                .Property(e => e.priceWithTAX)
                .HasPrecision(10, 2);
        }
    }
}
