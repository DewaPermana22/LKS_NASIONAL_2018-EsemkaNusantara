using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_2018
{
    public partial class FormManageMember : Form
    {
        private string connection = "Data Source=RPLSMKN8JBR\\SQLEXPRESS; Initial Catalog=LKS_2018; Integrated Security=true;";

        public FormManageMember()
        {
            InitializeComponent();
            LoadData();
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormManageMember_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertmmbr_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "INSERT INTO MsMember(Name,Email,Handphone,JoinDate) VALUES(@Name,@Email,@Handphone,@JoinDate) ";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Parameters.AddWithValue("@Name", txtnameMmbr.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEMailmmbr.Text);
                    cmd.Parameters.AddWithValue("@Handphone", txtPhoneMmbr.Text);
                    cmd.Parameters.AddWithValue("@JoinDate", DateTime.Now);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Berhasil Insert Data member!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPhoneMmbr.Text = string.Empty;
                txtnameMmbr.Text = string.Empty;
                txtIdMmbr.Text = string.Empty;
                txtEMailmmbr.Text = string.Empty;
                LoadData();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtIdMmbr.Text = row.Cells["MemberId"].Value.ToString();
                txtnameMmbr.Text = row.Cells["Name"].Value.ToString();
                txtEMailmmbr.Text = row.Cells["Email"].Value.ToString();
                txtPhoneMmbr.Text = row.Cells["Handphone"].Value.ToString();
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "SELECT * FROM MsMember";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                DataTable data = new DataTable();
                sqlDataAdapter.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

        private void btnUpdatemmbr_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "UPDATE MsMember SET Name = @Name, Handphone = @Handphone, Email = @Email WHERE MemberId = @MemberId";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Parameters.AddWithValue("@MemberId", txtIdMmbr.Text);
                    cmd.Parameters.AddWithValue("@Name", txtnameMmbr.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEMailmmbr.Text);
                    cmd.Parameters.AddWithValue("@Handphone", txtPhoneMmbr.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    txtPhoneMmbr.Text = string.Empty;
                    txtnameMmbr.Text = string.Empty;
                    txtIdMmbr.Text = string.Empty;
                    txtEMailmmbr.Text = string.Empty;
                    LoadData();
                }

                MessageBox.Show("Update Succesfully!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnDelMmbr_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "DELETE FROM MsMember WHERE MemberId = @MemberId";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Parameters.AddWithValue("@MemberId", txtIdMmbr.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    txtPhoneMmbr.Text = string.Empty;
                    txtnameMmbr.Text = string.Empty;
                    txtIdMmbr.Text = string.Empty;
                    txtEMailmmbr.Text = string.Empty;
                    LoadData();

                }
                MessageBox.Show("Delete Succesfully!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}
