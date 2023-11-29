namespace GUI
{
    partial class FrmClient
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.uC_FrmNghiepVu1 = new GUI.UserControl_FrmList.UC_FrmNghiepVu();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // uC_FrmNghiepVu1
            // 
            this.uC_FrmNghiepVu1.BackColor = System.Drawing.Color.White;
            this.uC_FrmNghiepVu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FrmNghiepVu1.Location = new System.Drawing.Point(0, 0);
            this.uC_FrmNghiepVu1.Name = "uC_FrmNghiepVu1";
            this.uC_FrmNghiepVu1.Size = new System.Drawing.Size(829, 537);
            this.uC_FrmNghiepVu1.TabIndex = 0;
            this.uC_FrmNghiepVu1.Load += new System.EventHandler(this.uC_FrmNghiepVu1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client";
            // 
            // FrmClient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 537);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_FrmNghiepVu1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClient";
            this.Text = "FrmClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label1;
        private UserControl_FrmList.UC_FrmNghiepVu uC_FrmNghiepVu1;
    }
}