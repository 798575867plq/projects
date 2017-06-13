using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WeiBo.dal.dao
{
    public class DBConn
    {
        public const string CONN_STRING =
            @"Data Source=.;Initial Catalog=WeiBo;Persist Security Info=True;User ID=sa;Password=abc123";
        public static SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection(CONN_STRING);
            conn.Open();
            return conn;
        }
    }
}