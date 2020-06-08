using OperatiiLimbaje.Contracts;
using OperatiiLimbaje.Exceptions;
using OperatiiLimbaje.Implementations;
using OperatiiLimbaje.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatiiLimbaje
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutomatReader automatReader = new AutomatFileReader();

         
            Automat automat1 = automatReader.ReadAutomat(@"../../automate/automat1.txt");

            Console.WriteLine("Automat1");
            Console.WriteLine("==================================");
            Console.WriteLine(automat1);

            Automat automat2 = automatReader.ReadAutomat(@"../../automate/automat2.txt");

            Console.WriteLine("Automat2");
            Console.WriteLine("=================================");
            Console.WriteLine(automat2);

            IOperatiiAutomateService operatiiAutomateService = new OperatiiAutomateService(new MultimeService());

            Automat produs = null;
            try
            {
                produs = operatiiAutomateService.Produs(automat1, automat2);
            }catch(AlfabeteDiferiteException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Produsul:");
            Console.WriteLine(produs);
           
            Console.ReadKey();
        }
    }
}