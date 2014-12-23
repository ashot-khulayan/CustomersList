using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersList.Module.Resources;

namespace CustomersList.Module.BusinessObjects
{
    public static class DbContextFactory
    {
        private static string connectionStringName;

        public static void Initialize(string connectionString)
        {
            connectionStringName = connectionString;
        }

        public static CustomersListDbContext Create()
        {
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new ConfigurationErrorsException(Strings.ConnStringConfigError);
            }

            return new CustomersListDbContext(connectionStringName);
        }
    }
}
