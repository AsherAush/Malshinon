using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Moduls
{
    public class Reports
    {
        public int ReporterId { get;  }
        public int TargetId { get;  }
        public string Text { get; }
    

    public Reports(int reporterId, int targetId, string text)
        {
            ReporterId = reporterId;
            TargetId = targetId;
            Text = text;
        }
    }
}
