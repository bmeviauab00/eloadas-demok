namespace Basic
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            filePicker1 = new FilePicker.FilePicker();
            SuspendLayout();
            // 
            // filePicker1
            // 
            filePicker1.Location = new Point(21, 23);
            filePicker1.Name = "filePicker1";
            filePicker1.FileParh = "c:\\";
            filePicker1.Size = new Size(419, 34);
            filePicker1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(filePicker1);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Basic demo";
            ResumeLayout(false);
        }

        #endregion

        private FilePicker.FilePicker filePicker1;
    }
}