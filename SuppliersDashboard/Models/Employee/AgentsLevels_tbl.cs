using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Models.Employee
{
    public class AgentsLevels_tbl
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public int Level  { get; set; }
        public int ParentId { get; set; }
        public int IsRoot { get; set; }
        public int IsActive { get; set; }
    }
}