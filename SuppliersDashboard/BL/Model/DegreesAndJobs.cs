using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoposERB.Models
{
    public class DegreesAndJobs
    {
        public int id { get; set; }
        public int JobID { get; set; }
        public string job_code { get; set; }
        public string job_adescipation { get; set; }
        public string job_edescipation { get; set; }
        public string job_degree { get; set; }
        public string job_tasks { get; set; }
        public string job_experince { get; set; }
        public string DegreeName { get; set; }
        public string DegreeCode { get; set; }
        public string job_terms { get; set; }
        public string job_responsabilities { get; set; }
        public decimal budget { get; set; }
    }
}