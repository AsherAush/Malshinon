using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Moduls
{
    internal class reports
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string ReporText { get; set; }
        public DateTime SubmittedAt { get; set; }
        public reports(int id, int reporterId, int targetId, string reportText, DateTime submittedAt)
        {
            Id = id;
            ReporterId = reporterId;
            TargetId = targetId;
            ReporText = reportText;
            SubmittedAt = submittedAt;
        }
    }
}
