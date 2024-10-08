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
// buat menangani image
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections;

namespace LKS_2018
{
    public partial class manageMenu : Form
    {
        private string connection = "Data Source=RPLSMKN8JBR\\SQLEXPRESS; Initial Catalog=LKS_2018; Integrated Security=true;";
        private string selectedImage = "";
        public manageMenu()
        {
            InitializeComponent();
             LoadData();
            // event handler click
         this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

          
        }

        private void manageMenu_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    string query = "INSERT INTO MsMenu ( name, price, photo) VALUES  (@name, @price, @photo)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {

                        command.Parameters.AddWithValue("@name", txtNameMenu.Text);
                        command.Parameters.AddWithValue("@price", txtPriceMenu.Text);
                        command.Parameters.AddWithValue("@photo", txtPhoto.Text);

                        conn.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Data gagal ditambahkan. Tidak ada baris yang terpengaruh.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        LoadData();
                        KondisiAwalSemua();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBrowsePhotoMenu_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c://";
                openFileDialog.Filter = "Images File(*jpg;*png;*webp;*jpeg;*JFIF)|*jpg;*png;*webp;*jpeg;*JFIF" ;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // ambil path image
                    selectedImage = openFileDialog.FileName;
                    //menampilkan di pict box
                    imgePreview.Image = Image.FromFile(selectedImage);
                    txtPhoto.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // fungsi agar ketika data grid view di klik maka datanya muncul di setiap textbox
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {

            if (e.RowIndex >= 0)
            {
                // ambil data dari baris yang di klik
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // isi setiap text box
                txtIdMenu.Text = row.Cells["menuid"].Value.ToString();
                txtNameMenu.Text = row.Cells["name"].Value.ToString();
                txtPriceMenu.Text = row.Cells["price"].Value.ToString();
                txtPhoto.Text = row.Cells["photo"].Value.ToString();
                // agar image preview nya jalan
                string imagePath = row.Cells["photo"].Value.ToString();
                string fullPath = Path.Combine("D:\\LATIHAN LKS 2025 ( DEWA PERMANA P S )\\LKS_2018\\LKS_2018\\Resources", imagePath);
                if (File.Exists(fullPath))
                {
                    if (imgePreview.Image != null)
                    {
                        imgePreview.Image.Dispose();
                    }
                    imgePreview.Image = Image.FromFile(fullPath);
                }
                else
                {

                    imgePreview.Image = null;
                }
            }
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM MsMenu";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    sqlDataAdapter.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : ", ex.Message);
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    string query = "UPDATE MsMenu SET name = @name, price = @price, photo = @photo WHERE menuid = @menuid";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@menuid", txtIdMenu.Text);
                        command.Parameters.AddWithValue("@name", txtNameMenu.Text);
                        command.Parameters.AddWithValue("@price", txtPriceMenu.Text);
                        command.Parameters.AddWithValue("@photo", txtPhoto.Text);
                        conn.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diUpdate!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Data gagal diUpdate. Tidak ada baris yang terpengaruh.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        LoadData();
                        KondisiAwalSemua();
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                } finally {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
            string query = "DELETE FROM MsMenu WHERE menuid = @menuid";
            using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@menuid",txtIdMenu.Text);
                    conn.Open();
                    int rowsAffected =  command.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Data gagal dihapus. Tidak ada baris yang terpengaruh.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }


        }

        private void KondisiAwalSemua()
        {
            txtIdMenu.Text = string.Empty;
            txtPriceMenu.Text = string.Empty;
            txtNameMenu.Text = string.Empty;
            txtPhoto.Text = string.Empty;
            imgePreview.Image = null;

        }
    }
}
