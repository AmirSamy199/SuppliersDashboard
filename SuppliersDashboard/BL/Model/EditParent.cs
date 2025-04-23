using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.Models
{
    public class EditParent
    {
        public List<SelectListItem> SelectList { get; set; }
        public string Label { get; set; }
        public bool Parent { get; set; }

    }
}