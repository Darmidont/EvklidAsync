using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateNumberMultithreads
{
    public class NumberCalculator
    {
        private List<int> _SimpleNumers;

        public NumberCalculator()
        {
            _SimpleNumers = new List<int>() { 2, 3 };
        }

        public int SimpleNumbersCount
        {
            get { return _SimpleNumers.Count; }
        }

        public void Start(int startValue, int maxValue, int step)
        {

            for (var i = startValue; i < maxValue; i += step)
            {
                Test(i);
            }
        }

        private void Test(int number)
        {
            var sqrtValue = (int)Math.Sqrt(number) + 1;

            for (int i = 0; sqrtValue > _SimpleNumers[i]; i++)
            {
                if (number % _SimpleNumers[i] == 0)
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
