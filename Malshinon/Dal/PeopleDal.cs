using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Compiler;
using Malshinon.Moduls;
using MySql.Data.MySqlClient;

namespace Malshinon.DAL
{
    static class PeopleDAL
    {
        public static int GetOrCreatePerson(string nameOrCode)
        {
            int? personId = GetPersonId(nameOrCode);
            if (personId.HasValue)
                return personId.Value;

            string secretCode = Guid.NewGuid().ToString();

              
            string fullName = IsSecretCodeFormat(nameOrCode) ? "Unknown" : nameOrCode;

            string insertQuery = $"INSERT INTO People (first_name, secret_code) VALUES ('{fullName}', '{secretCode}')";
            DBConnection.ExecuteNonQuery(insertQuery);

            return GetPersonId(secretCode) ?? throw new Exception("Failed to create person.");
        }

        public static int? GetPersonId(string nameOrCode)
        {
            string query;
            if (IsSecretCodeFormat(nameOrCode))
                query = $"SELECT Id FROM People WHERE secret_code = '{nameOrCode}'";
            else
                query = $"SELECT Id FROM People WHERE first_name = '{nameOrCode}'";

            var result = DBConnection.Execute(query);
            if (result.Count == 0)
                return null;

            return (int)(result[0]["Id"]);
        }

        public static string GetSecretCodeByName(string fullName)
        {
            string query = $"SELECT secret_code FROM People WHERE first_name = '{fullName}'";
            var result = DBConnection.Execute(query);
            if (result.Count == 0)
                return null;

            return (string)result[0]["secret_code"];
        }

        private static bool IsSecretCodeFormat(string input)
        {
            return Guid.TryParse(input, out _);
        }
    }
}