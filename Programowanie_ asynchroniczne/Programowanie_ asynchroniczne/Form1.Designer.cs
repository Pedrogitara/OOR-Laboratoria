namespace Programowanie__asynchroniczne
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
            this.btn_uruchom = new System.Windows.Forms.Button();
            this.lbl_napis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_uruchom
            // 
            this.btn_uruchom.Location = new System.Drawing.Point(50, 12);
            this.btn_uruchom.Name = "btn_uruchom";
            this.btn_uruchom.Size = new System.Drawing.Size(111, 23);
            this.btn_uruchom.TabIndex = 0;
            this.btn_uruchom.Text = "Uruchom zadanie";
            this.btn_uruchom.UseVisualStyleBackColor = true;
            this.btn_uruchom.Click += new System.EventHandler(this.btn_uruchom_Click);
            // 
            // lbl_napis
            // 
            this.lbl_napis.AutoSize = true;
            this.lbl_napis.Location = new System.Drawing.Point(47, 69);
            this.lbl_napis.Name = "lbl_napis";
            this.lbl_napis.Size = new System.Drawing.Size(9, 13);
            this.lbl_napis.TabIndex = 1;
            this.lbl_napis.Text = "l";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 124);
            this.Controls.Add(this.lbl_napis);
            this.Controls.Add(this.btn_uruchom);
            this.Name = "Form1";
            this.Text = "Programowanie asynchroniczne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_uruchom;
        private System.Windows.Forms.Label lbl_napis;
    }
}

