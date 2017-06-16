using System;
using AptManagement.Data.Models;

namespace AptManagement.Data.IRepos
{
    public interface IApartmentRepo
    {
        Apartment GetApartment(int AptID);
    }
}