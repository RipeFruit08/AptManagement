using AptManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptManagement.ViewModels
{
    public class ApartmentViewModel
    {
        public Apartment CurrentApt;
        public IEnumerable<Apartment> Apartments;
        public string SearchTerm;
    }
}