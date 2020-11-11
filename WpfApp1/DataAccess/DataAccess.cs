using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class DataAccess
    {
        public List<string> GetInfo(string tool)
        {
            // making sure our connection is cut cleanly
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LLOdatabase")))
            {
              var output = connection.Query<string>($"select Description from dbo.Tools where Name = '{ tool }'").ToList(); // requestion hammer description from database
              return output; // return List<string> to temp variable "combine" to convert List<string> to string
            }
        }
    }
}
