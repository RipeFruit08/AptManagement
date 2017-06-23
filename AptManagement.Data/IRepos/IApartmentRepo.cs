using System;
using AptManagement.Data.Models;
using System.Collections.Generic;

namespace AptManagement.Data.IRepos
{
    public interface IApartmentRepo
    {
        void AddApartment(Apartment apt);
        bool DeleteApartment(int AptID);
        Apartment GetApartment(int AptID);
        int GetMaxAptID();
        IEnumerable<Apartment> SearchApartments(string searchTerm);
        void UpdateApartment(Apartment apt);
    }
}