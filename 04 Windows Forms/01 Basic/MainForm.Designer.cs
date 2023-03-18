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
            tbName = new TextBox();
            bShow = new Button();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Location = new Point(34, 39);
            tbName.Name = "tbName";
            tbName.Size = new Size(192, 23);
            tbName.TabIndex = 0;
            tbName.Text = "apple";
            // 
            // bShow
            // 
            bShow.Location = new Point(253, 40);
            bShow.Name = "bShow";
            bShow.Size = new Size(75, 23);
            bShow.TabIndex = 1;
            bShow.Text = "Show";
            bShow.UseVisualStyleBackColor = true;
            bShow.Click += bShow_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(bShow);
            Controls.Add(tbName);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Basic demo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbName;
        private Button bShow;
    }
}