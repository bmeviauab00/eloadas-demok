using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCapture
{
    class Incrementer
    {
        int delta1 = 10;

        public void DoIt()
        {
            int delta2 = 10;

            Action<int> printIncremented = n => Console.WriteLine(n + delta1 + delta2);

            printIncremented(100);
        }
    }
}
