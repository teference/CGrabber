namespace CGrabber.Addin
{
    partial class AboutCGrabberView
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
            this.lblAboutUs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAboutUs
            // 
            this.lblAboutUs.AutoSize = true;
            this.lblAboutUs.Location = new System.Drawing.Point(12, 19);
            this.lblAboutUs.Name = "lblAboutUs";
            this.lblAboutUs.Size = new System.Drawing.Size(220, 18);
            this.lblAboutUs.TabIndex = 0;
            this.lblAboutUs.Text = "CGrabber - Contact Grabber";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "is brought to you by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jaspalsinh Chauhan (http://www.jsinh.in)";
            // 
            // AboutCGrabberView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 113);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAboutUs);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutCGrabberView";
            this.Text = "About CGrabber - Contact Grabber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAboutUs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}