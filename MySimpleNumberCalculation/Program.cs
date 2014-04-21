using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleNumberCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberManager numberManager = new NumberManager();
            numberManager.Start(5, 10000000);

            Console.WriteLine("Number of simples = {0}. Task has been executed for secs = {1}" , numberManager.SimpleNumbersCount, numberManager.Second);
            Console.WriteLine("End a program");
            Console.ReadLine();
        }
    }
}
