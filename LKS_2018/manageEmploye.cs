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
    public partial class manageEmploye : Form
    {
        string Koneksi = "Data Source=RPLSMKN8JBR\\SQLEXPRESS; Initial Catalog=LKS_2018; Integrated Security=true;";

        public manageEmploye()
        {
            InitializeComponent();
            LoadData();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

        }

        private void btnBckMngEmploye_Click(object sender, EventArgs e)
        {
        
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int numPass = 2;
            numPass++;

            using (SqlConnection sqlConnection = new SqlConnection(Koneksi))
            {
                sqlConnection.Open();
                using (SqlTransaction transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO MsEmploye(Name, Email, Handphone, Position, Password) VALUES (@Name, @Email, @Handphone, @Position, @Password)";
                        using (SqlCommand cmd = new SqlCommand(query, sqlConnection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", txtNameEmploye.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmailEmploye.Text);
                            cmd.Parameters.AddWithValue("@Handphone", txtHpEmploye.Text);
                            cmd.Parameters.AddWithValue("@Position", cmbPosition.Text.ToLower());
                            cmd.Parameters.AddWithValue("@Password", "testing");
                            // Set password berdasarkan posisi
                          
                            cmd.ExecuteNonQuery();
                        }

                        string query2 = "INSERT INTO MsMember(Name, Email, Handphone, JoinDate) VALUES (@Name, @Email, @Handphone, @JoinDate)";
                        using (SqlCommand sqlCommand = new SqlCommand(query2, sqlConnection, transaction))
                        {
                            sqlCommand.Parameters.AddWithValue("@Name", txtNameEmploye.Text);
                            sqlCommand.Parameters.AddWithValue("@Email", txtEmailEmploye.Text);
                            sqlCommand.Parameters.AddWithValue("@Handphone", txtHpEmploye.Text);
                            sqlCommand.Parameters.AddWithValue("@JoinDate", DateTime.Now);
                            sqlCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        LoadData();
                        ResetForm();
                        MessageBox.Show("Berhasil Menambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void LoadData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Koneksi))
            {
            string query = "SELECT EmployeId,CustomEmployeId,Name,Email,Handphone,Position FROM MsEmploye ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable data = new DataTable();
                sqlDataAdapter.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
                txtEmployeId.Text = dataGridViewRow.Cells["EmployeId"].Value.ToString();
                txtNameEmploye.Text = dataGridViewRow.Cells["Name"].Value.ToString();
                txtEmailEmploye.Text = dataGridViewRow.Cells["Email"].Value.ToString();
                txtHpEmploye.Text = dataGridViewRow.Cells["Handphone"].Value.ToString();
                cmbPosition.Text = dataGridViewRow.Cells["Position"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Koneksi))
            {
                string query = "UPDATE MsEmploye SET Name = @Name, Email = @Email, Handphone = @Handphone, Position = @Position WHERE EmployeId = @EmployeId";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                {

                cmd.Parameters.AddWithValue("@EmployeId", txtEmployeId.Text);
                cmd.Parameters.AddWithValue("@Name", txtNameEmploye.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmailEmploye.Text);
                cmd.Parameters.AddWithValue("@Handphone", txtHpEmploye.Text);
                cmd.Parameters.AddWithValue("@Position", cmbPosition.Text.ToLower());
                }
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
            ResetForm();
            MessageBox.Show("Data Berhasil di Perbarui!","Berhasil!",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Koneksi))
            {
                string query = "DELETE FROM MsEmploye WHERE EmployeId = @EmployeId";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                {
                    cmd.Parameters.AddWithValue("@EmployeId", txtEmployeId.Text);
                sqlConnection.Open();
                 cmd.ExecuteNonQuery();
                }

            }
            LoadData();
            ResetForm();
            MessageBox.Show("Data Berhasil di Hapus!","Berhasil",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ResetForm()
        {
            // Mengosongkan semua TextBox
            txtNameEmploye.Text = string.Empty;
            txtEmailEmploye.Text = string.Empty;
            txtHpEmploye.Text = string.Empty;
            cmbPosition.SelectedIndex = -1; // Mengosongkan ComboBox
        }

        private void manageEmploye_Load(object sender, EventArgs e)
        {

        }
    }


}
