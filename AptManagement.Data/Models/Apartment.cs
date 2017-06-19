using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AptManagement.Data.Models
{
    public class Apartment
    {
        public int    AptID { get; set; }

        public char   AptName { get; set; }
        
        [DisplayName("Apartment Number")]
        public int    AptNumber { get; set; }

        [DisplayName("Occupant #1")]
        public string TenantOne { get; set; }

        [DisplayName("Occupant #2")]
        public string TenantTwo { get; set; }
    }
}