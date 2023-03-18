namespace TimerCounter
{
    public partial class MainForm : Form
    {
        int count = 0;

        public MainForm()
        {
            InitializeComponent();

            // Frissítés átméretezéskor
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //UpdateStyles();

            // Vegyük ki a commentet, hogy ne villogjon a számláló!
            // DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            StringFormat format = new StringFormat();
            // Igazítás (Near – balra, Center, Far - jobbra)
            format.Alignment = StringAlignment.Center;
            // Horizontális igazítás (Near – fent, Center, Far - lent)
            format.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(count.ToString(), this.Font,
                    Brushes.Black, this.ClientRectangle, format);
        }


        private void bStartStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            bStartStop.Text = timer1.Enabled ? "Stop" : "Start";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ++count;
            Invalidate(); // Kritikus a hívása, kiváltja az újrarajzolást
        }
    }
}