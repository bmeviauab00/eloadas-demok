using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilePicker
{
    public partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            InitializeComponent();
        }

        public string FileParh
        {
            get { return tbFilePath.Text; }
            set { tbFilePath.Text = value; }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = Path.GetDirectoryName(tbFilePath.Text);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = dlg.FileName;
            }
        }
    }
}
