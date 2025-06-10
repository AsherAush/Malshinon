using System;
using System.Collections.Generic;
using System.Linq;
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
                        break;
                    case 2:
                        break;
                    case 3:
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
    }
}
