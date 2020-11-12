using System.Data;
using System.Data.SqlClient;

namespace MicroDojoWarrior.Read.Data
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