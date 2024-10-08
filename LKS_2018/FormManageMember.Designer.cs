namespace LKS_2018
{
    partial class FormManageMember
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdMmbr = new System.Windows.Forms.TextBox();
            this.txtnameMmbr = new System.Windows.Forms.TextBox();
            this.txtEMailmmbr = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInsertmmbr = new System.Windows.Forms.Button();
            this.btnUpdatemmbr = new System.Windows.Forms.Button();
            this.btnDelMmbr = new System.Windows.Forms.Button();
            this.txtPhoneMmbr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(717, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Form Manage Member";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "MemberId";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email";
            // 
            // txtIdMmbr
            // 
            this.txtIdMmbr.Enabled = false;
            this.txtIdMmbr.Location = new System.Drawing.Point(193, 253);
            this.txtIdMmbr.Multiline = true;
            this.txtIdMmbr.Name = "txtIdMmbr";
            this.txtIdMmbr.Size = new System.Drawing.Size(193, 29);
            this.txtIdMmbr.TabIndex = 3;
            // 
            // txtnameMmbr
            // 
            this.txtnameMmbr.Location = new System.Drawing.Point(193, 292);
            this.txtnameMmbr.Multiline = true;
            this.txtnameMmbr.Name = "txtnameMmbr";
            this.txtnameMmbr.Size = new System.Drawing.Size(193, 29);
            this.txtnameMmbr.TabIndex = 3;
            // 
            // txtEMailmmbr
            // 
            this.txtEMailmmbr.Location = new System.Drawing.Point(193, 328);
            this.txtEMailmmbr.Multiline = true;
            this.txtEMailmmbr.Name = "txtEMailmmbr";
            this.txtEMailmmbr.Size = new System.Drawing.Size(193, 29);
            this.txtEMailmmbr.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnInsertmmbr
            // 
            this.btnInsertmmbr.Location = new System.Drawing.Point(138, 419);
            this.btnInsertmmbr.Name = "btnInsertmmbr";
            this.btnInsertmmbr.Size = new System.Drawing.Size(95, 36);
            this.btnInsertmmbr.TabIndex = 4;
            this.btnInsertmmbr.Text = "Insert";
            this.btnInsertmmbr.UseVisualStyleBackColor = true;
            this.btnInsertmmbr.Click += new System.EventHandler(this.btnInsertmmbr_Click);
            // 
            // btnUpdatemmbr
            // 
            this.btnUpdatemmbr.Location = new System.Drawing.Point(239, 419);
            this.btnUpdatemmbr.Name = "btnUpdatemmbr";
            this.btnUpdatemmbr.Size = new System.Drawing.Size(95, 36);
            this.btnUpdatemmbr.TabIndex = 4;
            this.btnUpdatemmbr.Text = "Update";
            this.btnUpdatemmbr.UseVisualStyleBackColor = true;
            this.btnUpdatemmbr.Click += new System.EventHandler(this.btnUpdatemmbr_Click);
            // 
            // btnDelMmbr
            // 
            this.btnDelMmbr.Location = new System.Drawing.Point(340, 419);
            this.btnDelMmbr.Name = "btnDelMmbr";
            this.btnDelMmbr.Size = new System.Drawing.Size(95, 36);
            this.btnDelMmbr.TabIndex = 4;
            this.btnDelMmbr.Text = "Delete";
            this.btnDelMmbr.UseVisualStyleBackColor = true;
            this.btnDelMmbr.Click += new System.EventHandler(this.btnDelMmbr_Click);
            // 
            // txtPhoneMmbr
            // 
            this.txtPhoneMmbr.Location = new System.Drawing.Point(193, 363);
            this.txtPhoneMmbr.Multiline = true;
            this.txtPhoneMmbr.Name = "txtPhoneMmbr";
            this.txtPhoneMmbr.Size = new System.Drawing.Size(193, 32);
            this.txtPhoneMmbr.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(114, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Phone";
            // 
            // FormManageMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.txtPhoneMmbr);
            this.Controls.Add(this.btnDelMmbr);
            this.Controls.Add(this.btnUpdatemmbr);
            this.Controls.Add(this.btnInsertmmbr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEMailmmbr);
            this.Controls.Add(this.txtnameMmbr);
            this.Controls.Add(this.txtIdMmbr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormManageMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormManageMember";
            this.Load += new System.EventHandler(this.FormManageMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdMmbr;
        private System.Windows.Forms.TextBox txtnameMmbr;
        private System.Windows.Forms.TextBox txtEMailmmbr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInsertmmbr;
        private System.Windows.Forms.Button btnUpdatemmbr;
        private System.Windows.Forms.Button btnDelMmbr;
        private System.Windows.Forms.TextBox txtPhoneMmbr;
        private System.Windows.Forms.Label label5;
    }
}