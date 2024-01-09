using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAPI.Configurations
{
    public class Databases
    {
        public static string getDatabase()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["lojaConnection"].ConnectionString;
        }
        
    }
}