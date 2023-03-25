namespace FormBlock
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
            bRun_FromMainThread = new Button();
            bRun_FromNewThread = new Button();
            SuspendLayout();
            // 
            // bRun_FromMainThread
            // 
            bRun_FromMainThread.Location = new Point(35, 49);
            bRun_FromMainThread.Name = "bRun_FromMainThread";
            bRun_FromMainThread.Size = new Size(431, 34);
            bRun_FromMainThread.TabIndex = 0;
            bRun_FromMainThread.Text = "Run long running algoritm from main thread";
            bRun_FromMainThread.UseVisualStyleBackColor = true;
            bRun_FromMainThread.Click += bRun_FromMainThread_Click;
            // 
            // bRun_FromNewThread
            // 
            bRun_FromNewThread.Location = new Point(35, 111);
            bRun_FromNewThread.Name = "bRun_FromNewThread";
            bRun_FromNewThread.Size = new Size(431, 34);
            bRun_FromNewThread.TabIndex = 0;
            bRun_FromNewThread.Text = "Run long running algoritm from new thread";
            bRun_FromNewThread.UseVisualStyleBackColor = true;
            bRun_FromNewThread.Click += bRun_FromNewThread_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 313);
            Controls.Add(bRun_FromNewThread);
            Controls.Add(bRun_FromMainThread);
            Name = "Form1";
            Text = "Form block demo";
            ResumeLayout(false);
        }

        #endregion

        private Button bRun_FromMainThread;
        private Button bRun_FromNewThread;
    }
}