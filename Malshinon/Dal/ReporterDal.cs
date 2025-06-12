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


            //The following lines check with the agent the potential for an effective agent
            //Checks if he has entered more than 10 reports
            //And if so, it checks whether the average of its length is 100
            if (countReport > 10)
            {
                string avgMsgLengthQwery =
                    $"SELECT AVG(CHAR_LENGTH(text)) AS atl FROM intelreports WHERE reporter_id = {rprId}";
                var avgMsgLength = DBConnection.Execute(avgMsgLengthQwery);
                int countAvg = Convert.ToInt32(avgMsgLength[0]["atl"]);
                if (countAvg > 5)
                {
                    string insertPotentialQwery =
                    $"UPDATE people SET Potential_for = 'Effective agent' WHERE id = {rprId}";
                    DBConnection.ExecuteNonQuery(insertPotentialQwery);
                }

            }
            string ifHeve3ReportsIn15MinutsQwery =
                $"SELECT CASE  WHEN COUNT(*) >= 3 THEN TRUE ELSE FALSE END AS has_alert " +
                $"FROM intelreports" +
                $"WHERE target_id = {trgId}  AND timestamp >= NOW() - INTERVAL 15 MINUTE;";
            int ifHeve3ReportsIn15Minuts = Convert.ToInt32( DBConnection.Execute(ifHeve3ReportsIn15MinutsQwery));

            if (ifHeve3ReportsIn15Minuts == 1 || (countTerget > 20) )
            {
                string insertPotentialQwery =
                    $"UPDATE people SET Potential_for = 'Danger' WHERE id = {trgId}";
                DBConnection.ExecuteNonQuery(insertPotentialQwery);
            }




        }

    }
}
