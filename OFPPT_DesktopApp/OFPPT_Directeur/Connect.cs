using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OFPPT_Directeur
{
    class Connect
    {
        public SqlConnection Cnx = new SqlConnection();
        public SqlCommand Cmd = new SqlCommand();
        public SqlDataReader Dr;
        public void Connection(string CMD)
        {
            Cnx = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Connect"].ToString());
            if (Cnx.State == System.Data.ConnectionState.Open)
            {
                Cnx.Close();
            }
            else
            {
                Cnx.Open();
                Cmd = Cnx.CreateCommand();
                Cmd.CommandText = CMD;
            }
        }
        public void Deconnection()
        {
            Cnx.Close();
        }
    }
}
