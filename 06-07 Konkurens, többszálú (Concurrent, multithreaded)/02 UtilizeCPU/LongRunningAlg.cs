using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilizeCPU
{
    internal class LongRunningAlg
    {
        public static void Run_SingleThreaded()
        {
            Console.WriteLine("Starting on one thread.");
            // Process on a single thread
            // - Does not utilize multiple cpu cores. One thread can utilize one CPU core at a time.
            var sw = Stopwatch.StartNew();
            Process(new Range(0, 16_000_000_000));
            sw.Stop();
            Console.WriteLine($"Done. Duration: {sw.Elapsed}");
        }

        public static  void Run_MultipleThreaded()
        {
            // Process the date set in parallel by multiple threads:
            // - we can utilize multiples CPU cores (different threads can run on different CPU cores)
            // - finishes sooner on a multi CPU core system

            Console.WriteLine("Starting on multiple threads (ranges are processed in parallel by different threads, and thus by multiple cores (on a multicore mnachine).");

            var sw = Stopwatch.StartNew();

            var t1 = new Thread(Process);
            t1.Start(new Range(0, 2_000_000_000));

            var t2 = new Thread(Process);
            t2.Start(new Range(2_000_000_000, 4_000_000_000));

            var t3 = new Thread(Process);
            t3.Start(new Range(4_000_000_001, 6_000_000_000));

            var t4 = new Thread(Process);
            t4.Start(new Range(6_000_000_001, 8_000_000_000));

            var t5 = new Thread(Process);
            t5.Start(new Range(8_000_000_001, 10_000_000_000));

            var t6 = new Thread(Process);
            t6.Start(new Range(10_000_000_001, 12_000_000_000));

            var t7 = new Thread(Process);
            t7.Start(new Range(12_000_000_001, 14_000_000_000));

            var t8 = new Thread(Process);
            t8.Start(new Range(14_000_000_001, 16_000_000_000));

            // Wait for all threads to finish
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
            t7.Join();
            t8.Join();

            sw.Stop();
            Console.WriteLine($"Done. Duration: {sw.Elapsed}");
        }

        private static void Process(object oRange)
        {
            // Simulate long running algorithm
            Range range = (Range)oRange;
            // Simulate long running algorithm
            double d = 1;
            for (long i = range.From; i < range.To; i++)
            {
                d *= 1;
            }
        }
    }
}
