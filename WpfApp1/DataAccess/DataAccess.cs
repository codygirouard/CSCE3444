using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    public class DataAccess
    {
        MySqlConnection cn;
        SqlDataReader da;
        DataSet ds;

        public List<Tool> GetTools()
        {

            List<Tool> tools = new List<Tool>();
            string cnString = "Server=RANDALCARR5C00;Database=newdb;UID=mysqladmin;PWD=ranovoxo";
            cn = new MySqlConnection(cnString);
            cn.Open();
            string query = "Select * FROM tools";

            MySqlCommand cmd = new MySqlCommand(query, cn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                string name = reader["toolname"].ToString();
                string descrip = reader["tooldescription"].ToString();
                float price = (float)reader["toolprice"];
                int amount = (int)reader["toolamount"];

                Tool temp = new Tool(name, descrip, price, amount);
                tools.Add(temp);

            }
            cn.Close();

            return tools;

        }
    }
}
