using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Moduls
{
    internal class alerts
    {
        public int ID { get; set; }
        public int TargetId { get; set; }
        public DateTime WindowStart { get; set; }
        public DateTime WindowEnd { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }

        public alerts(int id, int targetId, DateTime windowStart, DateTime windowEnd, string reason, DateTime createdAt)
        {
            ID = id;
            TargetId = targetId;
            WindowStart = windowStart;
            WindowEnd = windowEnd;
            Reason = reason;
            CreatedAt = createdAt;
        }
    }
}
