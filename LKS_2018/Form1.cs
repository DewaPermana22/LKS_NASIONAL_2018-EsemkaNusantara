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

namespace LKS_2018
{
    public partial class FormLogin : Form
    {

        string Koneksi = "Data Source=RPLSMKN8JBR\\SQLEXPRESS; Initial Catalog=LKS_2018; Integrated Security=true;";
        public static string Position = string.Empty;
        public FormLogin()
        {

            InitializeComponent();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Koneksi))
            {
                connection.Open();
                string query = @"SELECT e.Employeid, e.Position, m.MemberId FROM MsEmploye e LEFT JOIN MsMember m ON e.Email = m.Email WHERE e.Email = @Email AND e.Password = @Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    // Ambil Position dan EmployeId dari hasil query
                    Position = reader["Position"].ToString().ToLower();
                    int EmployeId = Convert.ToInt32(reader["EmployeId"]);

                    // Simpan EmployeId ke dalam session
                    SessionUser.EmployeId = EmployeId;

                    if (!reader.IsDBNull(reader.GetOrdinal("MemberId")))
                    {
                        SessionUser.MemberId = Convert.ToInt32(reader["MemberId"]);
                    }
                    else
                    {
                        SessionUser.MemberId = null;
                    }

                    MessageBox.Show("Login Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Redirect ke form admin jika posisi adalah admin
                    if (Position == "admin")
                    {
                        admNav form2 = new admNav();
                        form2.ShowDialog();
                        this.Close();
                    } else if(Position == "chef")
                    {
                        ChefNav chef = new ChefNav();
                        chef.ShowDialog();
                        this.Close();
                    } else if(SessionUser.MemberId.HasValue)
                    {
                        FormOrder order = new FormOrder();
                        order.ShowDialog();
                        this.Close();
                    } else if (Position == "kasir")
                    {
                        CashierNav cashierNav = new CashierNav();
                        cashierNav.ShowDialog();
                        this.Close();
                    }
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("Login failed. Email or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }



    public static class SessionUser
    {
        public static int EmployeId { get; set; }
        public static int? MemberId { get; set;}
    }
}
