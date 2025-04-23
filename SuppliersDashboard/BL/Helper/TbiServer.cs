using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Helper
{
    public class TbiServer
    {
        public static DateTime Time(DateTime time)
        {
            return time.AddHours(9);
        }
    }
}