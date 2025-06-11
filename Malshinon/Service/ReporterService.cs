using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Dal;
using Malshinon.DAL;


namespace Malshinon.Service
{
    internal class ReporterService
    {
        string nameOrCodeReporter;
        string targetNameOrCode;
        string description;
        public static void ServiceReport()
        { 
        Console.WriteLine("Hello, please enter your name or your secrete code:");
        string nameOrCodeReporter = Console.ReadLine();
        // TODO: Check not null
        int reporterId = PeopleDAL.GetOrCreatePerson(nameOrCodeReporter);

        Console.WriteLine("enter the name or code of the target:");
        string targetNameOrCode = Console.ReadLine();
        int targetId  = PeopleDAL.GetOrCreatePerson(targetNameOrCode);

        Console.WriteLine("Enter a description of the event.");
        string description = Console.ReadLine();

        ReporterDal.InssertReport(reporterId, targetId, description);
        }
    }
}
