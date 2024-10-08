using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace LKS_2018
{
    public partial class FormGantiPass : Form
    {
        string Koneksi = "Data Source=RPLSMKN8JBR\\SQLEXPRESS; Initial Catalog=LKS_2018; Integrated Security=true;";
        public FormGantiPass()
        {
            InitializeComponent();
        }

        private void FormGantiPass_Load(object sender, EventArgs e)
        {
            txtnewpw.UseSystemPasswordChar = true;
            txtConfpw.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int UserId = SessionUser.EmployeId;
            if (string.IsNullOrEmpty(txtoldpw.Text) || string.IsNullOrEmpty(txtnewpw.Text) || string.IsNullOrEmpty(txtConfpw.Text)) {
                MessageBox.Show("Field Must be Filled!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (txtnewpw.Text != txtConfpw.Text)
            {
                MessageBox.Show("New Password and Confirmed Password do not Match!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Koneksi))
            {
                string query = "SELECT Password FROM MsEmploye WHERE EmployeId = @EmployeId";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@EmployeId", UserId);
                conn.Open();
                string PasswordOld = sqlCommand.ExecuteScalar().ToString();

                if (PasswordOld != txtoldpw.Text)
                {
                    MessageBox.Show("Password not found", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    conn.Close();
                    return;

                }

                string queryUpdte = "UPDATE  MsEmploye SET Password = @Password WHERE EmployeId = @EmployeId";
                sqlCommand = new SqlCommand(queryUpdte, conn);
                sqlCommand.Parameters.AddWithValue("@Password", txtnewpw.Text);
                sqlCommand.Parameters.AddWithValue("@EmployeId", UserId);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Password has been Change!", "Sucsess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                txtConfpw.Text = string.Empty;
                txtnewpw.Text = string.Empty;
                txtoldpw.Text = string.Empty;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtnewpw.UseSystemPasswordChar = false;
                txtConfpw.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfpw.UseSystemPasswordChar = true;
                txtnewpw.UseSystemPasswordChar= true;
            }
            }
        }

    }

