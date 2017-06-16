using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptManagement.Data.Context.Dapper.DBModels
{
    public class DBApartment
    {
        public int    AptID { get; set; }
        public char   AptName { get; set; }
        public int    AptNumber { get; set; }
        public string TenantOne { get; set; }
        public string TenantTwo { get; set; }
    }
}