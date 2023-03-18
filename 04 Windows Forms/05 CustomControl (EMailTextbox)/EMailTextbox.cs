using System.ComponentModel;

namespace CustomControl
{
    /// <summary>
    /// Textbox for entering and e-mail address (performs validation).
    /// </summary>
    public partial class EmailTextBox : TextBox
    {
        private Color backColorSave = System.Drawing.SystemColors.Window;
        private bool firstChange = true;

        [
         Category("Appearance"),
         Description("Defines color for invalid email")
        ]
        public Color InvalidColor { set; get; } = Color.HotPink;

        protected override void OnTextChanged(EventArgs e)
        {
            if (IsValid() || DesignMode)
                this.BackColor = backColorSave;
            else
            {
                if (firstChange)
                {
                    backColorSave = BackColor;
                    firstChange = false;
                }
                this.BackColor = InvalidColor;
            }

            base.OnTextChanged(e);
        }

        protected bool IsValid()
        {
            return System.Text.RegularExpressions.Regex.IsMatch(this.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
