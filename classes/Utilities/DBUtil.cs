using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Utilities
{
    internal class DBUtil
    {
        private static IConfiguration _iconfig;
        static DBUtil()
        {
            GetAppSettings();
        }
        private static void GetAppSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _iconfig = builder.Build();
        }

        public static string GetConnection()
        {
            return _iconfig.GetConnectionString("LocalConnectionString");
        }

    }
}
