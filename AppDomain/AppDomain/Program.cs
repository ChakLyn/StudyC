using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with the defult AppDomain\n");
            DispalyDADStuts();
            Console.ReadLine();
        }

        private static void DispalyDADStuts()
        {
            // Get access to the domain of the program for current thread
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Log out different static data about this domain
            Console.WriteLine($"Name of this domain: {defaultAD.FriendlyName}");
            Console.WriteLine($"ID of domain in this process: {defaultAD.Id}");
            Console.WriteLine($"Is this the defualt domain?: {defaultAD.IsDefaultAppDomain()}");
            Console.WriteLine($"Base dircetory of this domain: {defaultAD.BaseDirectory}");
        }
    }
}
