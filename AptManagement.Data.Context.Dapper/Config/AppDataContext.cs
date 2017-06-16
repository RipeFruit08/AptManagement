using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.SqlServer;

namespace AptManagement.Data.Context.Dapper.Config
{
    public class AppDataContext : IDisposable
    {
        private IDbConnection _mydb;

        internal IDbConnection MYDB
        {
            get
            {
                return _mydb ?? (_mydb = GetConnection("MYDB"));
            }
        }

        private static IDbConnection GetConnection(string name)
        {
            var settings = ConfigurationManager.ConnectionStrings[name];
            if (settings == null)
                throw new InvalidOperationException("Invalid connection string name.");

            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = factory.CreateConnection();
            if (connection == null)
                throw new InvalidOperationException("Invalid connection.");

            connection.ConnectionString = settings.ConnectionString;
            return connection;
        }

        public void SaveChanges() { }

        public void Dispose()
        {
            MYDB.Dispose();
        }
    }
}