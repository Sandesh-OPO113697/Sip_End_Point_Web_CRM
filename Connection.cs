using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCRM
{
    class Connection
    {
        public SqlConnection getconn()
        {
            string datasource = ConfigurationSettings.AppSettings["DataSource"];
            string initialcatalog = ConfigurationSettings.AppSettings["InitialCatalog"];
            string persistsecurityinfo = ConfigurationSettings.AppSettings["PersistSecurityInfo"];
            SqlConnection con = new SqlConnection("Data Source=" + datasource + ";Initial Catalog=" + initialcatalog + ";Persist Security Info=" + persistsecurityinfo + ";User ID=sa;Password=sa@123");
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Open();
            return con;
        }

       
    }
}
