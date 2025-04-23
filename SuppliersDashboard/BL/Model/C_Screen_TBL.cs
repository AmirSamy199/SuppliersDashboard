using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.BL.Model
{
    public partial class C_Screen_TBL
    {


        public int Screen_ID { get; set; }
        public Nullable<int> screen_tran_module_id { get; set; }
        public string screen_Aname { get; set; }
        public string screen_Ename { get; set; }
        public Nullable<byte> screen_status { get; set; }


    } 
}