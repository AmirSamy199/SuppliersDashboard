using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.ViewModels
{
    public class MarketTableVM
    {
        public int State { get; set; }
        public List<TableData> data { get; set; }

    }

    public class TableData
    {
        public string item { get; set; }
        public int Customer_ID { get; set; }
    }

}