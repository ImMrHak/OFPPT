using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace OFPPT.Models
{
    public class ConnectDB
    {
        public SqlConnection Cnx = new SqlConnection();
        public SqlCommand Cmd = new SqlCommand();
        public SqlDataReader Dr;
        public void Connection(string CMD)
        {
            Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
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