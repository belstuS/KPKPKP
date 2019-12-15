using System.Data.SqlClient;
using System.Web.Configuration;

namespace Auction.Repositories
{
    public class SQLConnector
    {
        static string connectionString = WebConfigurationManager.ConnectionStrings["AdminConnection"].ConnectionString;

        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }
    }
}