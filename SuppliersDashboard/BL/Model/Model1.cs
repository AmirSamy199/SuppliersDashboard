using SuppliersDashboard.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SuppliersDashboard.BL.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<ETA_document_Tbl> ETA_document_Tbl { get; set; }
        public virtual DbSet<Evn_Bill_Detiles_Tbl> Evn_Bill_Detiles_Tbl { get; set; }
        public virtual DbSet<Evn_Bill_Tax_Tbl> Evn_Bill_Tax_Tbl { get; set; }
        public virtual DbSet<Evn_Bill_Tbl> Evn_Bill_Tbl { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.NumberOfUnits)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.ItemDiscount_rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.ItemDiscount_amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.currencyExchangeRate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.SubmittionUUID)
                .IsUnicode(false);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.GrossTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Detiles_Tbl>()
                .Property(e => e.Vat)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tax_Tbl>()
                .Property(e => e.TAX_Rate)
                .IsFixedLength();

            modelBuilder.Entity<Evn_Bill_Tax_Tbl>()
                .Property(e => e.TaxAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.Discount_Amt)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.Discount_Rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.WTHOLDINGTAX)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.WTHOLDINGTAX_Rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.VAT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.TotalAmountBeforDiscount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.TotalAmountAfterDiscount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.TotalAmountAfterVAT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.VAT_Prs)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Evn_Bill_Tbl>()
                .Property(e => e.currencyExchangeRate)
                .HasPrecision(10, 2);
        }
    }
}
