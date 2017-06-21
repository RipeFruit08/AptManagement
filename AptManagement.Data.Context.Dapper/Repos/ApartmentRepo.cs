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
        public void AddApartment(Apartment apt)
        {
            try
            {
                Context.MYDB.Query<Apartment>(
                    Queries.Query.AddApartment, GetAddParams(apt));
            }
            catch (SqlException exc)
            {
                Debug.WriteLine(exc);
            }
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
        public int GetMaxAptID()
        {
            int result = 0;
            try
            {
                result = Context.MYDB.Query<int>(
                    Queries.Query.MaxAptID).FirstOrDefault();
            }
            catch (SqlException exc)
            {
                Debug.WriteLine(exc);
            }
            return result;
        }
        public IEnumerable<Apartment> SearchApartments(string searchTerm)
        {
            IEnumerable<Apartment> results = null;
            try
            {
                results = Context.MYDB.Query<Apartment>(
                    Queries.Query.SearchApartments, new { searchTerm });
            }
            catch (SqlException exc)
            {
                Debug.WriteLine(exc);
            }
            return results;
        }
        public void UpdateApartment(Apartment apt)
        {
            try
            {
                Context.MYDB.Query<Apartment>(
                    Queries.Query.UpdateApartment, GetEditParams(apt));
            }
            catch (SqlException exc)
            {
                Debug.WriteLine(exc);
            }
        }
        private DynamicParameters GetAddParams(Apartment apt)
        {
            DynamicParameters Params = new DynamicParameters();
            Params.Add("AptName", apt.AptName);
            Params.Add("AptNumber", apt.AptNumber);
            Params.Add("TenantOne", apt.TenantOne);
            Params.Add("TenantTwo", apt.TenantTwo);
            return Params;
        }
        private DynamicParameters GetEditParams(Apartment apt)
        {
            DynamicParameters Params = new DynamicParameters();
            Params.Add("AptID", apt.AptID);
            Params.Add("AptName", apt.AptName);
            Params.Add("AptNumber", apt.AptNumber);
            Params.Add("TenantOne", apt.TenantOne);
            Params.Add("TenantTwo", apt.TenantTwo);
            return Params;
        }
    }
}