using FormsAndDialogs;

namespace StripsAndTimer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            timer1.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int newVal = toolStripProgressBar1.Value + 10;
            if (newVal <= toolStripProgressBar1.Maximum)
                toolStripProgressBar1.Value = newVal;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();

            // Példa modális megjelenítésre
            form.Interval = timer1.Interval;
            if (form.ShowDialog() == DialogResult.OK)
            {
                timer1.Interval = form.Interval;
            }

            // Példa nem modális megjelenítésre
            // form.Show(this);
        }
    }
}