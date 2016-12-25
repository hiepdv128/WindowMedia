using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace WindowMedia
{
    class ResourceTransporter
    {
        private string uri = "Data Source=DESKTOP-MB70NCN\\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True;MultipleActiveResultSets=True";
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
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM AllResource WHERE name=N'{0}'", key),
                this.GetConnection());

            return command.ExecuteScalar() != null;
        }


        public Dictionary<string, string> readFromResources(string type, string username)
        {
            string query = String.Format(
                "SELECT name, url FROM Resources WHERE type='{0}' AND username='{1}'", type, username
            );

            SqlDataReader reader = new SqlCommand(query, GetConnection()).ExecuteReader();
            Dictionary<string, string> dictionary = reader.Cast<DbDataRecord>()
                .ToDictionary(row => row["name"].ToString(), row => row["url"].ToString());

            return dictionary;
        }

        public List<string> readFromPlayListItem(string playlist, string username)
        {
            string query = String.Format(
                "SELECT ResourceName FROM PlayListItems WHERE playList='{0}' AND username='{1}'", playlist, username
            );

            SqlDataReader reader = new SqlCommand(query, GetConnection()).ExecuteReader();
            return reader.Cast<DbDataRecord>()
                .Select(record => (string) record["ResourceName"])
                .ToList();
        }
    }
}