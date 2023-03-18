namespace CustomControl
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
            label1 = new Label();
            label2 = new Label();
            emailTextBox1 = new EmailTextBox();
            emailTextBox2 = new EmailTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 34);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Primary e-mail:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 75);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 0;
            label2.Text = "Secondary e-mail:";
            // 
            // emailTextBox1
            // 
            emailTextBox1.BackColor = SystemColors.Window;
            emailTextBox1.InvalidColor = Color.HotPink;
            emailTextBox1.Location = new Point(134, 34);
            emailTextBox1.Name = "emailTextBox1";
            emailTextBox1.Size = new Size(184, 23);
            emailTextBox1.TabIndex = 1;
            // 
            // emailTextBox2
            // 
            emailTextBox2.BackColor = SystemColors.Window;
            emailTextBox2.InvalidColor = Color.HotPink;
            emailTextBox2.Location = new Point(134, 72);
            emailTextBox2.Name = "emailTextBox2";
            emailTextBox2.Size = new Size(184, 23);
            emailTextBox2.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 272);
            Controls.Add(emailTextBox2);
            Controls.Add(emailTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Custom controls";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private EmailTextBox emailTextBox1;
        private EmailTextBox emailTextBox2;
    }
}