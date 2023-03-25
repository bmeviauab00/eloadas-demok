using System;

namespace UtilizeCPU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LongRunningAlg(object oRange)
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

        private void bRun_SingleThread_Click(object sender, EventArgs e)
        {
            // Process on a single thread
            // - Does not utilize multiple cpu cores. One thread can utilize one CPU core at a time.
            LongRunningAlg(new Range(0, 16_000_000_000));
            MessageBox.Show("Done");
        }

        private void bRun_MultipleThreads_Click(object sender, EventArgs e)
        {
            // Process the date set in parallel by multiple threads:
            // - we can utilize multiples CPU cores (different threads can run on different CPU cores)
            // - finishes sooner on a multi CPU core system

            var t1 = new Thread(LongRunningAlg);
            t1.Start(new Range(0, 2_000_000_000));

            var t2 = new Thread(LongRunningAlg);
            t2.Start(new Range(2_000_000_000, 4_000_000_000));

            var t3 = new Thread(LongRunningAlg);
            t3.Start(new Range(4_000_000_000, 6_000_000_000));

            var t4 = new Thread(LongRunningAlg);
            t4.Start(new Range(6_000_000_000, 8_000_000_000));

            var t5 = new Thread(LongRunningAlg);
            t5.Start(new Range(8_000_000_000, 10_000_000_000));

            var t6 = new Thread(LongRunningAlg);
            t6.Start(new Range(10_000_000_000, 12_000_000_000));

            var t7 = new Thread(LongRunningAlg);
            t7.Start(new Range(12_000_000_000, 14_000_000_000));

            var t8 = new Thread(LongRunningAlg);
            t8.Start(new Range(14_000_000_000, 16_000_000_000));

            // Wait for all threads to finish (not necessary, just for the sake of displaying a messagebox in the end
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
            t7.Join();
            t8.Join();

            MessageBox.Show("Done");
        }
    }
}