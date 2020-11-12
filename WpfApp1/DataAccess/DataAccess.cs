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
        public Tool GetInfo(string tool)
        {
            // making sure our connection is cut cleanly
            // Helper.CnnVal("LLOdatabase") returns the connection string
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LLOdatabase")))
            {
                Tool tempTool = new Tool();
                List<int> tempStock;

                // requestion hammer description from database
                List<string> output = connection.Query<string>($"select Description from dbo.Tools where Name = '{ tool }'").ToList();
                string combine = string.Join("", output); //converting the list of the description to one string
                tempTool.Description = combine;

                // Get tool name
                output = connection.Query<string>($"select Name from dbo.Tools where Name = '{ tool }'").ToList();
                combine = string.Join("", output); //converting the list of the description to one string
                tempTool.Name = combine;

                // Get tool price
                List<float> outputPrice = connection.Query<float>($"select Price from dbo.Tools where Name = '{ tool }'").ToList();
                tempTool.Price = outputPrice.ElementAt(0);

                // Get tool Stock amount
                tempStock = connection.Query<int>($"select Quantity from dbo.Tools where Name = '{ tool }'").ToList();              
                tempTool.Name = combine;
                tempTool.Quantity = tempStock.ElementAt(0);

                return tempTool; // return List<string> to temp variable "combine" to convert List<string> to string
            }
        }
    }
}
