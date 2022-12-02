using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrderSync.Utility
{
    public class DB
    {
        protected SqlConnection connection = new SqlConnection(UtilVarClass.connectionString);
        protected SqlCommand command;
        protected SqlDataAdapter adapter;
        protected DataSet ds;
        protected DataTable dt;
    }
}
