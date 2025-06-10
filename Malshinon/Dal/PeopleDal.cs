using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Dal
{
    internal static class PeopleDal
    {
        public static void AddPeople(People people)
        {
            string sql = $@"  
                          INSERT INTO People(firstName, lastName, secretCode, type)  
                          VALUES ('{people.FirstName}', '{people.LastName}','{people.SecretCode}','{people.Type}');";

            //int printmassage =  DBConnection.ExecuteNonQuery(sql);
            //Console.WriteLine($"{printmassage}  rows insterted");
        }


    }
}

