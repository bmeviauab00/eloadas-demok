namespace Keyboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Form1_KeyDown: " + e.KeyCode.ToString());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            MessageBox.Show("OnKeyDown: " + e.KeyCode.ToString());
        }
    }
}