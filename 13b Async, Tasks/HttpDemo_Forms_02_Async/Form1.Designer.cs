namespace HttpDemo_Forms
{
    partial class Form1
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
            bGetContentLength = new Button();
            label1 = new Label();
            lContentLength = new Label();
            SuspendLayout();
            // 
            // bGetContentLength
            // 
            bGetContentLength.Location = new Point(30, 58);
            bGetContentLength.Name = "bGetContentLength";
            bGetContentLength.Size = new Size(171, 47);
            bGetContentLength.TabIndex = 0;
            bGetContentLength.Text = "Get content length";
            bGetContentLength.UseVisualStyleBackColor = true;
            bGetContentLength.Click += bGetContentLength_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 21);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 1;
            label1.Text = "Content length:";
            // 
            // lContentLength
            // 
            lContentLength.AutoSize = true;
            lContentLength.Location = new Point(178, 21);
            lContentLength.Name = "lContentLength";
            lContentLength.Size = new Size(36, 25);
            lContentLength.TabIndex = 1;
            lContentLength.Text = "???";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 128);
            Controls.Add(lContentLength);
            Controls.Add(label1);
            Controls.Add(bGetContentLength);
            Name = "Form1";
            Text = "GetContent - Async";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bGetContentLength;
        private Label label1;
        private Label lContentLength;
    }
}