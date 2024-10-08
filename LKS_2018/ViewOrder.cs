using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LKS_2018
{
    public partial class ViewOrder : Form
    {
        private string Koneksi = "Data Source=RPLSMKN8JBR\\SQLEXPRESS; Initial Catalog=LKS_2018; Integrated Security=true;";
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private SqlCommand cmd;

        public ViewOrder()
        {
            InitializeComponent();
            conn = new SqlConnection(Koneksi); // Inisialisasi koneksi ke database
        }

        private void ViewOrder_Load(object sender, EventArgs e)
        {
            dataOrder(); // Load data order saat form dimuat
        }

        // Fungsi untuk mengambil dan menampilkan data CustomDetailId di ComboBox
        private void dataOrder()
        {
            try
            {
                // Query untuk mengambil CustomDetailId dari DetailOrder
                cmd = new SqlCommand("SELECT CustomDetailId FROM DetailOrder", conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Mengisi ComboBox dengan data CustomDetailId
                cmb1.DataSource = dt;
                cmb1.DisplayMember = "CustomDetailId";
                cmb1.ValueMember = "CustomDetailId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order data: " + ex.Message);
            }
        }

        // Event saat ComboBox dipilih, untuk memproses pesanan berdasarkan CustomDetailId
        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb1.SelectedValue != null)
            {
                statusOrder(); // Memanggil fungsi untuk menampilkan status pesanan
            }
        }

        // Fungsi untuk menampilkan status pesanan berdasarkan CustomDetailId yang dipilih
        private void statusOrder()
        {
            // Mendapatkan nilai CustomDetailId yang dipilih dari ComboBox
            string customDetailId = (cmb1.SelectedValue as DataRowView)?["CustomDetailId"].ToString();

            if (!string.IsNullOrEmpty(customDetailId)) // Cek jika CustomDetailId tidak null atau kosong
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open(); // Buka koneksi jika belum terbuka
                }

                try
                {
                    // Query untuk mengambil data pesanan
                    string query = @"SELECT CustomDetailId, MsMenu.name, DetailOrder.Qty, DetailOrder.Status 
                                     FROM MsMenu 
                                     INNER JOIN DetailOrder ON MsMenu.menuid = DetailOrder.menuid 
                                     WHERE DetailOrder.CustomDetailId = @CustomDetailId AND DetailOrder.Status <> 'Finished'";

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomDetailId", customDetailId); // Parameter untuk query

                    adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt; // Tampilkan data di DataGridView

                        // Pastikan kolom "Action" hanya ditambahkan sekali
                        if (!dataGridView1.Columns.Contains("Action"))
                        {
                            // Tambahkan kolom ComboBox untuk status
                            DataGridViewComboBoxColumn actionColumn = new DataGridViewComboBoxColumn
                            {
                                HeaderText = "Action",
                                DataPropertyName = "Status"
                            };
                            actionColumn.Items.AddRange("Cooking", "Deliver", "Pending");

                            dataGridView1.Columns.Add(actionColumn);
                        }

                        // Daftarkan event untuk perubahan nilai status
                        dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                    }
                    else
                    {
                        MessageBox.Show("No data found for the selected CustomDetailId.");
                        dataGridView1.DataSource = null; // Kosongkan DataGridView jika tidak ada data
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading order status: " + ex.Message);
                }
                finally
                {
                    conn.Close(); // Tutup koneksi setelah query selesai
                }
            }
            else
            {
                MessageBox.Show("CustomDetailId is not valid. Please select a valid order.");
            }
        }

        // Event untuk menangani perubahan status di DataGridView
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan indeks valid dan kolom yang diubah adalah kolom "Action"
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Action"].Index)
            {
                string newStatus = dataGridView1.Rows[e.RowIndex].Cells["Action"].Value?.ToString();
                string customDetailId = dataGridView1.Rows[e.RowIndex].Cells["CustomDetailId"].Value?.ToString();

                if (!string.IsNullOrEmpty(newStatus) && !string.IsNullOrEmpty(customDetailId))
                {
                    // Query untuk update status di DetailOrder
                    string updateQuery = "UPDATE DetailOrder SET Status = @Status WHERE CustomDetailId = @CustomDetailId";
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }

                        using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Status", newStatus);
                            cmdUpdate.Parameters.AddWithValue("@CustomDetailId", customDetailId);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        MessageBox.Show("Status berhasil diubah!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating status: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close(); // Tutup koneksi setelah update
                    }
                }
                else
                {
                    MessageBox.Show("Invalid data for status update.");
                }
            }
        }

        // Event handler untuk klik konten dalam DataGridView (bisa diimplementasikan jika dibutuhkan)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implementasikan logika jika ada aksi saat sel di-klik (jika dibutuhkan)
        }
    }
}
