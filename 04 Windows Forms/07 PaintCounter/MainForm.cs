namespace PaintCounter
{
    public partial class MainForm : Form
    {
        int count;

        public MainForm()
        {
            InitializeComponent();

            // 01. Frissítés átméretezéskor
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            UpdateStyles();

            // 03. Duplapufferelés engedélyezése
            //SetStyle(ControlStyles.DoubleBuffer |
            //    ControlStyles.UserPaint |
            //    ControlStyles.AllPaintingInWmPaint,
            //    true);
            // UpdateStyles();

            // DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            StringFormat format = new StringFormat();
            // Igazítás (Near – balra, Center, Far - jobbra)
            format.Alignment = StringAlignment.Center;
            // Horizontális igazítás (Near – fent, Center, Far - lent)
            format.LineAlignment = StringAlignment.Center;

            ++count;
            e.Graphics.DrawString(count.ToString(), this.Font,
                    Brushes.Black, this.ClientRectangle, format);
        }

    }
}