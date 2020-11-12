using System.Data;
using System.Data.SqlClient;

namespace MicroDojoPurchase.Read.Data
{
    public class ReadDbContext
    {
        public readonly IDbConnection db;

        public ReadDbContext(string connString)
        {
            db = new SqlConnection(connString);
        }
    }
}