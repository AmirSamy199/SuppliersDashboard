using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models
{
    public class RegisterOnlineShopRequest_tbl
    {
        //                

        [Key]
        public int RecordId { get; set; }
        public string BranchName { get; set; }
        public string CompanyName { get; set; }
        public string OfficeName { get; set; }
        public string Password { get; set; }
        public byte status { get; set; }
        public DateTime? Request_date { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int? OnlineBranchId { get; set; }

    
    }
}