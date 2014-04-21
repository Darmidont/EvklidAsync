using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateNumberMultithreads
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteUsingTasks();

            Console.WriteLine("End a program");
            Console.ReadLine();
        }

        private static void ExecuteByTaskFactory()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var numberCalculator = new NumberCalculator();
            //numberCalculator.Start(5, 10000000);
            var maxVal = 10000000;
            numberCalculator.Start(5, 10000, 2);

            var tasks = new List<Task>();
            for (int i = 0; i < 4; i++)
            {
                var task = Task.Factory.StartNew(() => numberCalculator.Start(10001 + i * 2, 10000000, 8));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();
            var elapsedSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000);

            Console.WriteLine("Program has been executed for {0} secs, found {1} simple numbers", elapsedSeconds, numberCalculator.SimpleNumbersCount);
        }

        private static void ExecuteUsingTasks()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var numberCalculator = new NumberCalculator();
            //numberCalculator.Start(5, 10000000);
            var maxVal = 10000000;
            numberCalculator.Start(5, 10000, 2);

            Task task1 = new Task(() => numberCalculator.Start(10001, 10000000, 8));
            Task task2 = new Task(() => numberCalculator.Start(10003, 10000000, 8));
            Task task3 = new Task(() => numberCalculator.Start(10005, 10000000, 8));
            Task task4 = new Task(() => numberCalculator.Start(10007, 10000000, 8));

            task1.Start();
            //task1.Wait();
            task2.Start();
            //task2.Wait();
            task3.Start();
            //task3.Wait();
            task4.Start();
            //task4.Wait();

            task1.Wait();
            task2.Wait();
            task3.Wait();
            task4.Wait();
            stopwatch.Stop();
            var elapsedSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000);

            Console.WriteLine("Program has been executed for {0} secs, found {1} simple numbers", elapsedSeconds, numberCalculator.SimpleNumbersCount);
        }
    }
}
