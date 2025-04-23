using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SuppliersDashboard.Models
{
    public partial class Model4 : DbContext
    {
        public Model4()
            : base("name=Model4")
        {
        }

        public virtual DbSet<VAT_tbl> VAT_tbl { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
