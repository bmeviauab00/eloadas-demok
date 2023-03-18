namespace Basic
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tbName.Text);

            // Try this:
            // while (true);
        }
    }
}