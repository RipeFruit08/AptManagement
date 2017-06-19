using System;
using AptManagement.Data.Models;

namespace AptManagement.Data.IRepos
{
    public interface IApartmentRepo
    {
        void AddApartment(Apartment apt);
        Apartment GetApartment(int AptID);
        int GetMaxAptID();
    }
}