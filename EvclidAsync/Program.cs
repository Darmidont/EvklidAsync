using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvclidAsync
{
    internal class Program
    {
        private static List<int> SimpleNumber = null;


        private static void Main(string[] args)
        {
            SimpleNumber = new List<int>(new int[] { 3 });
            int N = 10000000;
            DateTime begin, end;
            begin = DateTime.Now;
            SimpleCalculator(5, N, 2);
            end = DateTime.Now;
            Console.WriteLine("Один поток {0} c. Простых чисел: {1}", end.Subtract(begin).TotalSeconds, SimpleNumber.Count);
            Console.ReadKey();
            Console.WriteLine("End a program");
            Console.ReadLine();
        }

        private static void SimpleCalculator(int p_begin, int p_end, int p_steep)
        {
            for (int i = p_begin; i < p_end; i += p_steep)
            {
                TestNumber(i);
            }
        }

        private static void TestNumber(int p_number)
        {
            int sqrt = (int) Math.Sqrt(p_number) + 1;
            int i = 0;
            while (SimpleNumber[i] < sqrt)
            {
                if (p_number%SimpleNumber[i] == 0)
                {
                    return;
                }
                i++;
            }
            lock (SimpleNumber)
            {
                SimpleNumber.Add(p_number);
            }
        }
    }
}