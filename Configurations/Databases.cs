using System.Configuration;

namespace WebAPI.Configurations
{
    public class Databases
    {
        public static string getDatabase()
        {
            return ConfigurationManager.ConnectionStrings["lojaConnection"].ConnectionString;
        }
        
    }
}