namespace FormBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LongRunningAlg()
        {
            // Simulate long running algorithm
            double d = 1;
            for (long i = 0; i < 3_000_000_000; i++)
            {
                d *= 1;
            }
            MessageBox.Show("Done");
        }

        private void bRun_FromMainThread_Click(object sender, EventArgs e)
        {
            // Call from main thread, UI freezes
            LongRunningAlg();
        }

        private void bRun_FromNewThread_Click(object sender, EventArgs e)
        {
            // Call from a new thread, UI does not freeze
            Thread thread = new Thread(LongRunningAlg);
            thread.Start();
        }
    }
}