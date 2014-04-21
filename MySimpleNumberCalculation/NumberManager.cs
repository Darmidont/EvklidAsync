using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleNumberCalculation
{
    public class NumberManager
    {
        private List<int> _SimpleNumers; 
        public NumberManager()
        {
            _SimpleNumers = new List<int>(){2, 3};
        }

        public int SimpleNumbersCount
        {
            get { return _SimpleNumers.Count; }
        }

        private int _elapsedSeconds = 0;

        public int Second
        {
            get { return _elapsedSeconds; }
        }
        public void Start(int startValue, int maxValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (var i = startValue; i < maxValue; i+=2)
            {
                Test(i);
            }

            stopwatch.Stop();
            _elapsedSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
        }

        private void Test(int number)
        {
            var sqrtValue = (int) Math.Sqrt(number) + 1;

            for (int i = 0; sqrtValue > _SimpleNumers[i]; i++)
            {
                if(number%_SimpleNumers[i] == 0)
                {
                    return;
                }
            }

            lock (_SimpleNumers)
            {
                    _SimpleNumers.Add(number);
            }
        }
    }
}
