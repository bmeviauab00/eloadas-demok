namespace FormsAndDialogs
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbInterval = new TextBox();
            bOk = new Button();
            bCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Interval";
            // 
            // tbInterval
            // 
            tbInterval.Location = new Point(78, 24);
            tbInterval.Name = "tbInterval";
            tbInterval.Size = new Size(100, 23);
            tbInterval.TabIndex = 1;
            // 
            // bOk
            // 
            bOk.Location = new Point(235, 19);
            bOk.Name = "bOk";
            bOk.Size = new Size(75, 23);
            bOk.TabIndex = 2;
            bOk.Text = "Ok";
            bOk.UseVisualStyleBackColor = true;
            bOk.Click += bOk_Click;
            // 
            // bCancel
            // 
            bCancel.Location = new Point(235, 57);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(75, 23);
            bCancel.TabIndex = 3;
            bCancel.Text = "Cancel";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = bCancel;
            CausesValidation = false;
            ClientSize = new Size(330, 106);
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Controls.Add(tbInterval);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbInterval;
        private Button bOk;
        private Button bCancel;
    }
}