using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AptManagement.Data.Context.Dapper.Queries
{
    internal static class Query
    {
        public static string AddApartment { get; private set; }
        public static string DeleteApartment { get; private set; }
        public static string GetApartment { get; private set; }
        public static string MaxAptID { get; private set; }
        public static string SearchApartments { get; private set; }
        public static string UpdateApartment { get; private set; }

        private static IEnumerable<string> SqlFilePaths { get; set; }

        static Query()
        {
            SqlFilePaths =
                Assembly.GetCallingAssembly().GetManifestResourceNames();
            LoadQueries();
        }

        private static void LoadQueries()
        {
            Type type = typeof(Query);
            PropertyInfo[] properties =
                type.GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach(PropertyInfo property in properties)
            {
                string query = LoadQuery(property);
                // some Moog specific shit went here
                property.SetValue(null, query);
            }
        }

        private static string LoadQuery(PropertyInfo property)
        {
            string path =
                SqlFilePaths.FirstOrDefault(
                    x => x.EndsWith(property.Name + ".sql"));
            using (
                Stream stream = 
                    Assembly.GetCallingAssembly()
                        .GetManifestResourceStream(path))
            {
                return stream == null ? null : new StreamReader(stream).ReadToEnd();
            }
        }
    }
}