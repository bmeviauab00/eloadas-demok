namespace FilePicker
{
    partial class FilePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbFilePath = new TextBox();
            label1 = new Label();
            bBrowse = new Button();
            SuspendLayout();
            // 
            // tbFilePath
            // 
            tbFilePath.Location = new Point(50, 8);
            tbFilePath.Name = "tbFilePath";
            tbFilePath.Size = new Size(269, 23);
            tbFilePath.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 11);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 1;
            label1.Text = "File:";
            // 
            // bBrowse
            // 
            bBrowse.Location = new Point(325, 7);
            bBrowse.Name = "bBrowse";
            bBrowse.Size = new Size(75, 23);
            bBrowse.TabIndex = 2;
            bBrowse.Text = "Browse...";
            bBrowse.UseVisualStyleBackColor = true;
            bBrowse.Click += bBrowse_Click;
            // 
            // FilePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bBrowse);
            Controls.Add(label1);
            Controls.Add(tbFilePath);
            Name = "FilePicker";
            Size = new Size(419, 34);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbFilePath;
        private Label label1;
        private Button bBrowse;
    }
}
