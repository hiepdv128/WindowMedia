﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowMedia
{
    class ResourceTransporter
    {
        private string uri = "Data Source=(localdb)\\v11.0;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        private SqlConnection connection;

        public ResourceTransporter()
        {
            this.connection = new SqlConnection(uri);
        }

        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public bool CheckResourceExist(string key)
        {
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM AllResource WHERE name=N'{0}'", key), this.GetConnection());

            return command.ExecuteScalar() != null;
        }

    }
}