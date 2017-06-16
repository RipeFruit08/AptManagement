using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using AptManagement.Data.Context.Dapper.DBModels;
using AptManagement.Data.Context.Dapper.Config;
using AptManagement.Data.Models;
using AptManagement.Data.IRepos;
using System.Linq;
using System.Web;

namespace AptManagement.Data.Context.Dapper.Repos
{
    public class ApartmentRepo : IApartmentRepo
    {
        private AppDataContext Context;
        private AppModelMapper Map;

        public ApartmentRepo(AppDataContext context)
        {
            Context = context;
            Map = new AppModelMapper();
        }
        public Apartment GetApartment(int AptID)
        {
            Apartment result = null;
            try
            {
                result = 
                    Context.MYDB.Query<Apartment>(
                        Queries.Query.GetApartment, new { AptID }).
                        FirstOrDefault();
            }
            catch (SqlException exc)
            {
                Debug.WriteLine(exc);
            }
            return result;
        }
    }
}