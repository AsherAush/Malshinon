using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class people
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Secretcode { get; set; }
        public DateTime CreatedAt { get; set; }

        public people(int id, string fullname, string secretcode, DateTime createdAt)
        {
            Id = id;
            Fullname = fullname;
            Secretcode = secretcode;
            CreatedAt = createdAt;
        }


    }
}
