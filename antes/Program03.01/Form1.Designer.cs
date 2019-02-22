namespace Program03._01
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
            this.btnRelogio = new System.Windows.Forms.Button();
            this.txtRelogio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRelogio
            // 
            this.btnRelogio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelogio.Location = new System.Drawing.Point(130, 42);
            this.btnRelogio.Name = "btnRelogio";
            this.btnRelogio.Size = new System.Drawing.Size(143, 38);
            this.btnRelogio.TabIndex = 0;
            this.btnRelogio.Text = "Iniciar";
            this.btnRelogio.UseVisualStyleBackColor = true;
            this.btnRelogio.Click += new System.EventHandler(this.btnRelogio_Click);
            // 
            // txtRelogio
            // 
            this.txtRelogio.BackColor = System.Drawing.Color.Black;
            this.txtRelogio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelogio.ForeColor = System.Drawing.Color.White;
            this.txtRelogio.Location = new System.Drawing.Point(130, 108);
            this.txtRelogio.Name = "txtRelogio";
            this.txtRelogio.Size = new System.Drawing.Size(143, 29);
            this.txtRelogio.TabIndex = 1;
            this.txtRelogio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 209);
            this.Controls.Add(this.txtRelogio);
            this.Controls.Add(this.btnRelogio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRelogio;
        private System.Windows.Forms.TextBox txtRelogio;
    }
}

