using Malshinon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Service;
using Malshinon.Moduls;
using Mysqlx.Crud;


namespace Malshinon.Dal
{
    static class ReporterDal
    {
        public static void InssertReport(int rprId, int trgId, string text)
        {
            //Enters a report
            string insertQuery =
                  $"INSERT INTO intelreports (reporter_id, target_id, text) " +
                  $"VALUES ('{rprId}', '{trgId}', '{text}')";
            DBConnection.ExecuteNonQuery(insertQuery);

            //Checks how many reports have already been submitted
            string numOfReportQwery =
                $"SELECT COUNT(*) AS c FROM intelreports WHERE reporter_id = '{rprId}'";
            var numOfReport = DBConnection.Execute(numOfReportQwery);
            int countReport = Convert.ToInt32(numOfReport[0]["c"]);

            //Updating how many messages have already been entered
            string updateNumReport =
                $"UPDATE people SET num_reports = {countReport} WHERE id = {rprId}";
            DBConnection.ExecuteNonQuery(updateNumReport);

            //Check how many times we've already updated reports on it.
            string numOfTargetQwery =
                $"SELECT COUNT(*) AS c FROM intelreports WHERE target_id = '{trgId}'";
            var numOftarget = DBConnection.Execute(numOfTargetQwery);
            int countTerget = Convert.ToInt32(numOftarget[0]["c"]);

            //Corrects how many reports there are about it
            string updateNumTarget =
                $"UPDATE people SET num_mentions = {countTerget} WHERE id = {trgId}";
            DBConnection.ExecuteNonQuery (updateNumTarget);








        }

    }
}
