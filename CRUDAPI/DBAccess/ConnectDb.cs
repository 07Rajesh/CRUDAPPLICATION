﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.DBAccess
{
    public class ConnectDb
    {
       
        public SqlConnection connection { get; set; }
        public ConnectDb()
        {
            connection = new SqlConnection(ConnectionString.ConnectionStr);
        }

    }
}
