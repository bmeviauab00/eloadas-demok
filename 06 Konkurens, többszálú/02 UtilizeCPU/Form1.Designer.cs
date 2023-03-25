namespace UtilizeCPU
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
            bRun_SingleThread = new Button();
            bRun_MultipleThreads = new Button();
            SuspendLayout();
            // 
            // bRun_SingleThread
            // 
            bRun_SingleThread.Location = new Point(35, 49);
            bRun_SingleThread.Name = "bRun_SingleThread";
            bRun_SingleThread.Size = new Size(431, 34);
            bRun_SingleThread.TabIndex = 0;
            bRun_SingleThread.Text = "Process on single thread";
            bRun_SingleThread.UseVisualStyleBackColor = true;
            bRun_SingleThread.Click += bRun_SingleThread_Click;
            // 
            // bRun_MultipleThreads
            // 
            bRun_MultipleThreads.Location = new Point(35, 111);
            bRun_MultipleThreads.Name = "bRun_MultipleThreads";
            bRun_MultipleThreads.Size = new Size(431, 34);
            bRun_MultipleThreads.TabIndex = 0;
            bRun_MultipleThreads.Text = "Process in parallel by multiple threads";
            bRun_MultipleThreads.UseVisualStyleBackColor = true;
            bRun_MultipleThreads.Click += bRun_MultipleThreads_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 313);
            Controls.Add(bRun_MultipleThreads);
            Controls.Add(bRun_SingleThread);
            Name = "Form1";
            Text = "Form block demo";
            ResumeLayout(false);
        }

        #endregion

        private Button bRun_SingleThread;
        private Button bRun_MultipleThreads;
    }
}