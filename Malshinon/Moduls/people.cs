using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public enum PeopleType
    {
        Reporter,
        Target,
        Both,
        PotentialAgent
    }
    public class People
    {


        public string FirstName { get; }
        public string LastName { get; }
        public string SecretCode { get; }
        public PeopleType Type { get; }

        public People(string firstName, string lastName, string secretCode, PeopleType type)
        {
            FirstName = firstName;
            LastName = lastName;
            SecretCode = secretCode;
            Type = type;
        }
    }

}
