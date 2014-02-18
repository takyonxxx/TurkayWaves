namespace TurkayWaves
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.hScrollfreq = new System.Windows.Forms.HScrollBar();
            this.labelfrq = new System.Windows.Forms.Label();
            this.playtime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(9, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hScrollfreq
            // 
            this.hScrollfreq.LargeChange = 1;
            this.hScrollfreq.Location = new System.Drawing.Point(9, 85);
            this.hScrollfreq.Maximum = 22000;
            this.hScrollfreq.Name = "hScrollfreq";
            this.hScrollfreq.Size = new System.Drawing.Size(502, 21);
            this.hScrollfreq.TabIndex = 1;
            this.hScrollfreq.Value = 1000;
            this.hScrollfreq.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollfreq_Scroll);
            // 
            // labelfrq
            // 
            this.labelfrq.AutoSize = true;
            this.labelfrq.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelfrq.Location = new System.Drawing.Point(213, 121);
            this.labelfrq.Name = "labelfrq";
            this.labelfrq.Size = new System.Drawing.Size(112, 25);
            this.labelfrq.TabIndex = 2;
            this.labelfrq.Text = "16000 Hz";
            // 
            // playtime
            // 
            this.playtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.playtime.Location = new System.Drawing.Point(150, 41);
            this.playtime.Name = "playtime";
            this.playtime.Size = new System.Drawing.Size(59, 31);
            this.playtime.TabIndex = 3;
            this.playtime.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(215, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seconds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 169);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playtime);
            this.Controls.Add(this.labelfrq);
            this.Controls.Add(this.hScrollfreq);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HScrollBar hScrollfreq;
        private System.Windows.Forms.Label labelfrq;
        private System.Windows.Forms.TextBox playtime;
        private System.Windows.Forms.Label label1;
    }
}

