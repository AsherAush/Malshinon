using Malshinon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Malshinon.Service

{
    internal class Menu
    {
        public static void menu()
        {
            while (true)
            {
                Console.WriteLine(
                        "Hello to the Melshinot system - please select one of the options:\n" +
                        "1. Submit report.\n" +
                        "2. Import reports from CSV.\n" +
                        "3. Show secret code by name.\n" +
                        "4. Analysis dashboard.\n" +
                        "5. Exit."
);


                if (int.TryParse(Console.ReadLine(), out int choich)) { 
                switch (choich)
                {
                    case 1:
                            ReporterService.ServiceReport();
                            break;
                    case 2:
                        break;
                    case 3:
                            ShowSecretCodeByName();
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Exting....");
                        return;
                    default:
                        Console.WriteLine("invalid choich. Please enter yue are choich: ");
                        break;
                }
                }
                else
                {
                    Console.WriteLine("please enter a number:");
                }
            }
        }

        public static void ShowSecretCodeByName()
        {
            Console.WriteLine("Enter the name of the person you are looking for.");
            string name = Console.ReadLine();
            string show = PeopleDAL.GetSecretCodeByName(name);
            if (show != null)
            {
                Console.WriteLine($"The code for {name}  is: {show}.");
            }
            else
            {
                Console.WriteLine($"The system did not find a person by that {name}.");
            }
        }
    }
}
