using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormsAndDialogs
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private int interval;

        public int Interval
        {
            get { return interval; }
            set
            {
                interval = value;
                tbInterval.Text = value.ToString();
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbInterval.Text, out interval))
                MessageBox.Show("Érvénytelen érték!");
            else
                this.DialogResult = DialogResult.OK;
        }
    }
}
