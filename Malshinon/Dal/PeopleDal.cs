using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Dal
{
    internal class PeopleDal
    {


        private readonly string _connectionString;

        public PeopleDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InsertPerson(People people)
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string sql = @"INSERT INTO People (first_name, last_name, secret_code, type)
                       VALUES (@first, @last, @code, @type)";
            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@first", people.FirstName);
            cmd.Parameters.AddWithValue("@last", people.LastName);
            cmd.Parameters.AddWithValue("@code", people.SecretCode);
            cmd.Parameters.AddWithValue("@type", people.Type.ToString().ToLower());

            cmd.ExecuteNonQuery();
            int newId = (int)cmd.LastInsertedId;

            return newId;
        }
    }

}

