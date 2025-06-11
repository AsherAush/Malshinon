using Malshinon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Service;


namespace Malshinon.Dal
{
    static class ReporterDal
    {
        public static void InssertReport(int rprId, int trgId, string text)
        {
            string inssertQery =
                 $"INSERT INTO intelreports (reporter_id, target_id, text) " +
                 $"VALUES ('{rprId}', '{trgId}', '{text}')";
            DBConnection.ExecuteNonQuery(inssertQery);

        }
    }
}
