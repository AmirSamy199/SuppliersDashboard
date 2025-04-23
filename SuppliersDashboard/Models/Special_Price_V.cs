using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersDashboard.Models
{
    public class Special_Price_VV
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string BranchName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
       public string ConfirmBy { get; set; }
       public decimal Amount { get; set; }

    }
}
