namespace PaintCounter
{
    public partial class MainForm : Form
    {
        int count;

        public MainForm()
        {
            InitializeComponent();

            // 01. Friss�t�s �tm�retez�skor
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            UpdateStyles();

            // 03. Duplapufferel�s enged�lyez�se
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
            // Igaz�t�s (Near � balra, Center, Far - jobbra)
            format.Alignment = StringAlignment.Center;
            // Horizont�lis igaz�t�s (Near � fent, Center, Far - lent)
            format.LineAlignment = StringAlignment.Center;

            ++count;
            e.Graphics.DrawString(count.ToString(), this.Font,
                    Brushes.Black, this.ClientRectangle, format);
        }

    }
}