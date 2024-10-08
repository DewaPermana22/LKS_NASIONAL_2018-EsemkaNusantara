namespace LKS_2018
{
    partial class manageMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manageMenu));
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtIdMenu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameMenu = new System.Windows.Forms.TextBox();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.imgePreview = new System.Windows.Forms.PictureBox();
            this.txtPriceMenu = new System.Windows.Forms.TextBox();
            this.btnInsertMenu = new System.Windows.Forms.Button();
            this.btnBrowsePhotoMenu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(279, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Form Manage Menu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(730, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtIdMenu
            // 
            this.txtIdMenu.Enabled = false;
            this.txtIdMenu.Location = new System.Drawing.Point(112, 248);
            this.txtIdMenu.Multiline = true;
            this.txtIdMenu.Name = "txtIdMenu";
            this.txtIdMenu.Size = new System.Drawing.Size(164, 28);
            this.txtIdMenu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "MenuId";
            // 
            // txtNameMenu
            // 
            this.txtNameMenu.Location = new System.Drawing.Point(112, 282);
            this.txtNameMenu.Multiline = true;
            this.txtNameMenu.Name = "txtNameMenu";
            this.txtNameMenu.Size = new System.Drawing.Size(164, 28);
            this.txtNameMenu.TabIndex = 3;
            // 
            // txtPhoto
            // 
            this.txtPhoto.Enabled = false;
            this.txtPhoto.Location = new System.Drawing.Point(112, 352);
            this.txtPhoto.Multiline = true;
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(164, 28);
            this.txtPhoto.TabIndex = 3;
            this.txtPhoto.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // imgePreview
            // 
            this.imgePreview.Image = global::LKS_2018.Properties.Resources.blank_profile_picture_973460_1280;
            this.imgePreview.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgePreview.InitialImage")));
            this.imgePreview.Location = new System.Drawing.Point(427, 251);
            this.imgePreview.Name = "imgePreview";
            this.imgePreview.Size = new System.Drawing.Size(139, 129);
            this.imgePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgePreview.TabIndex = 5;
            this.imgePreview.TabStop = false;
            // 
            // txtPriceMenu
            // 
            this.txtPriceMenu.Location = new System.Drawing.Point(112, 318);
            this.txtPriceMenu.Multiline = true;
            this.txtPriceMenu.Name = "txtPriceMenu";
            this.txtPriceMenu.Size = new System.Drawing.Size(164, 28);
            this.txtPriceMenu.TabIndex = 3;
            this.txtPriceMenu.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // btnInsertMenu
            // 
            this.btnInsertMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnInsertMenu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnInsertMenu.Location = new System.Drawing.Point(123, 395);
            this.btnInsertMenu.Name = "btnInsertMenu";
            this.btnInsertMenu.Size = new System.Drawing.Size(105, 36);
            this.btnInsertMenu.TabIndex = 6;
            this.btnInsertMenu.Text = "Insert";
            this.btnInsertMenu.UseVisualStyleBackColor = false;
            this.btnInsertMenu.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBrowsePhotoMenu
            // 
            this.btnBrowsePhotoMenu.Location = new System.Drawing.Point(297, 357);
            this.btnBrowsePhotoMenu.Name = "btnBrowsePhotoMenu";
            this.btnBrowsePhotoMenu.Size = new System.Drawing.Size(51, 23);
            this.btnBrowsePhotoMenu.TabIndex = 8;
            this.btnBrowsePhotoMenu.Text = ".....";
            this.btnBrowsePhotoMenu.UseVisualStyleBackColor = true;
            this.btnBrowsePhotoMenu.Click += new System.EventHandler(this.btnBrowsePhotoMenu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Price";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Photo";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Location = new System.Drawing.Point(265, 395);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 36);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Location = new System.Drawing.Point(389, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 36);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // manageMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnBrowsePhotoMenu);
            this.Controls.Add(this.btnInsertMenu);
            this.Controls.Add(this.imgePreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPriceMenu);
            this.Controls.Add(this.txtPhoto);
            this.Controls.Add(this.txtNameMenu);
            this.Controls.Add(this.txtIdMenu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "manageMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGE MENU FORM";
            this.Load += new System.EventHandler(this.manageMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtIdMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameMenu;
        private System.Windows.Forms.TextBox txtPhoto;
        private System.Windows.Forms.PictureBox imgePreview;
        private System.Windows.Forms.TextBox txtPriceMenu;
        private System.Windows.Forms.Button btnInsertMenu;
        private System.Windows.Forms.Button btnBrowsePhotoMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}