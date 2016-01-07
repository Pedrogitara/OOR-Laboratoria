namespace Wielowatkowosc_kwadraty
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
            this.btn_watek_1 = new System.Windows.Forms.Button();
            this.btn_watek_2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_watek_1
            // 
            this.btn_watek_1.Location = new System.Drawing.Point(12, 12);
            this.btn_watek_1.Name = "btn_watek_1";
            this.btn_watek_1.Size = new System.Drawing.Size(113, 23);
            this.btn_watek_1.TabIndex = 0;
            this.btn_watek_1.Text = "Wątek czerwony";
            this.btn_watek_1.UseVisualStyleBackColor = true;
            this.btn_watek_1.Click += new System.EventHandler(this.btn_watek_1_Click);
            // 
            // btn_watek_2
            // 
            this.btn_watek_2.Location = new System.Drawing.Point(12, 52);
            this.btn_watek_2.Name = "btn_watek_2";
            this.btn_watek_2.Size = new System.Drawing.Size(113, 23);
            this.btn_watek_2.TabIndex = 1;
            this.btn_watek_2.Text = "Wątek niebieski";
            this.btn_watek_2.UseVisualStyleBackColor = true;
            this.btn_watek_2.Click += new System.EventHandler(this.btn_watek_2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_watek_2);
            this.Controls.Add(this.btn_watek_1);
            this.Name = "Form1";
            this.Text = "Wielowątkowość - kwadraty";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_watek_1;
        private System.Windows.Forms.Button btn_watek_2;
    }
}

