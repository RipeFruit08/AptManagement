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

        /// <summary>
        /// Adds an Apartment entry in the database based on the Apartment
        /// passed in
        /// </summary>
        /// <param name="apt">
        ///     The Apartment object that will be added to the database
        /// </param>
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

        /// <summary>
        /// Deletes an Apartment entry in the database specified by its AptID
        /// </summary>
        /// <param name="AptID">the AptID of the Apartment to delete</param>
        /// <returns>
        ///     true on successful delete; false otherwise
        /// </returns>
        public bool DeleteApartment(int AptID)
        {
            try
            {
                Context.MYDB.Query<Apartment>(
                    Queries.Query.DeleteApartment, new { AptID });
                return true;
            }
            catch (SqlException exc)
            {
                Debug.WriteLine(exc);
                return false;
            }
        }

        /// <summary>
        /// Fetches an Apartment entry in the database specified by its AptID
        /// </summary>
        /// <param name="AptID">the AptID of the Apartment to fetch</param>
        /// <returns>
        ///     An Apartment object corresponding to that Apartment entry in
        ///     the database. If no match is found, null is returned
        /// </returns>
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

        /// <summary>
        /// Gets the current highest AptID in the database.
        /// </summary>
        /// <returns>the highest AptID in the database</returns>
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

        /// <summary>
        /// Searches the database for Apartment(s) matching the searchTerm.
        ///
        /// See the query for how it is specifically searching
        /// </summary>
        /// <param name="searchTerm">the search term</param>
        /// <returns>
        ///     An IEnumerable of Apartment objects. If no results are found
        ///     then an empty IEnumerable will be returned
        /// </returns>
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

        /// <summary>
        /// Updates an apartment entry in the database specified by its AptID
        /// </summary>
        /// <param name="apt">
        ///     A modified Apartment object corresponding to the Apartment
        ///     entry that will be editied
        /// </param>
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

        /// <summary>
        /// Builds the dynamic parameter object for the AddApartment
        /// database call.
        /// </summary>
        /// <param name="apt"></param>
        /// <returns></returns>
        private DynamicParameters GetAddParams(Apartment apt)
        {
            DynamicParameters Params = new DynamicParameters();
            Params.Add("AptName", apt.AptName);
            Params.Add("AptNumber", apt.AptNumber);
            Params.Add("TenantOne", apt.TenantOne);
            Params.Add("TenantTwo", apt.TenantTwo);
            return Params;
        }

        /// <summary>
        /// Builds the dynamic parameter object for the UpdateApartment
        /// database call.
        /// </summary>
        /// <param name="apt"></param>
        /// <returns></returns>
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