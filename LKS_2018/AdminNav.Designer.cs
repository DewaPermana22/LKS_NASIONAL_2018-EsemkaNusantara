namespace LKS_2018
{
    partial class admNav
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mngEmploye = new System.Windows.Forms.Button();
            this.btnManageMenu = new System.Windows.Forms.Button();
            this.btnManageMember = new System.Windows.Forms.Button();
            this.btnCgPw = new System.Windows.Forms.Button();
            this.lgBtnAdm = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN NAVIGATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // mngEmploye
            // 
            this.mngEmploye.Location = new System.Drawing.Point(145, 167);
            this.mngEmploye.Name = "mngEmploye";
            this.mngEmploye.Size = new System.Drawing.Size(157, 35);
            this.mngEmploye.TabIndex = 2;
            this.mngEmploye.Text = "Manage Employe";
            this.mngEmploye.UseVisualStyleBackColor = true;
            this.mngEmploye.Click += new System.EventHandler(this.mngEmploye_Click);
            // 
            // btnManageMenu
            // 
            this.btnManageMenu.Location = new System.Drawing.Point(145, 208);
            this.btnManageMenu.Name = "btnManageMenu";
            this.btnManageMenu.Size = new System.Drawing.Size(157, 37);
            this.btnManageMenu.TabIndex = 2;
            this.btnManageMenu.Text = "Manage Menu";
            this.btnManageMenu.UseVisualStyleBackColor = true;
            this.btnManageMenu.Click += new System.EventHandler(this.btnManageMenu_Click);
            // 
            // btnManageMember
            // 
            this.btnManageMember.Location = new System.Drawing.Point(145, 263);
            this.btnManageMember.Name = "btnManageMember";
            this.btnManageMember.Size = new System.Drawing.Size(157, 38);
            this.btnManageMember.TabIndex = 2;
            this.btnManageMember.Text = "Manage Member";
            this.btnManageMember.UseVisualStyleBackColor = true;
            this.btnManageMember.Click += new System.EventHandler(this.btnManageMember_Click);
            // 
            // btnCgPw
            // 
            this.btnCgPw.Location = new System.Drawing.Point(145, 359);
            this.btnCgPw.Name = "btnCgPw";
            this.btnCgPw.Size = new System.Drawing.Size(157, 38);
            this.btnCgPw.TabIndex = 2;
            this.btnCgPw.Text = "Change Password";
            this.btnCgPw.UseVisualStyleBackColor = true;
            this.btnCgPw.Click += new System.EventHandler(this.button4_Click);
            // 
            // lgBtnAdm
            // 
            this.lgBtnAdm.Location = new System.Drawing.Point(145, 409);
            this.lgBtnAdm.Name = "lgBtnAdm";
            this.lgBtnAdm.Size = new System.Drawing.Size(157, 38);
            this.lgBtnAdm.TabIndex = 2;
            this.lgBtnAdm.Text = "Logout";
            this.lgBtnAdm.UseVisualStyleBackColor = true;
            this.lgBtnAdm.Click += new System.EventHandler(this.lgBtnAdm_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(145, 307);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(157, 36);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "View Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // admNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 484);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lgBtnAdm);
            this.Controls.Add(this.btnCgPw);
            this.Controls.Add(this.btnManageMember);
            this.Controls.Add(this.btnManageMenu);
            this.Controls.Add(this.mngEmploye);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "admNav";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMIN NAVIGATION";
            this.Load += new System.EventHandler(this.admNav_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mngEmploye;
        private System.Windows.Forms.Button btnManageMenu;
        private System.Windows.Forms.Button btnManageMember;
        private System.Windows.Forms.Button btnCgPw;
        private System.Windows.Forms.Button lgBtnAdm;
        private System.Windows.Forms.Button btnReport;
    }
}