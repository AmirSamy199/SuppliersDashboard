using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class ConfirmDash
    {
        public int Pending { get; set; }
        public int Cancelled { get; set; }
        public int Confirm { get; set; }
    }
}