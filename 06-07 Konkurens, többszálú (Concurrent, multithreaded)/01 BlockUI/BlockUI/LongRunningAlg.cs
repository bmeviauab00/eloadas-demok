using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockUI
{
    static internal class LongRunningAlg
    {
        public static void Run()
        {
            // Simulate long running algorithm
            double d = 1;
            for (long i = 0; i < 3_000_000_000; i++)
                d *= 1;
        }
    }
}
