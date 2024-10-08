using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LKS_2018
{
    public partial class FormOrder : Form
    {
        string koneksi = "Data Source=RPLSMKN8JBR\\SQLEXPRESS; Initial Catalog=LKS_2018; Integrated Security=true;";
        private List<int> menuid = new List<int>();
        private int orderIdSemenTara = 1;
        private string OrderId;

        public FormOrder()
        {
            InitializeComponent();
            LoadData();
            LoadDataorder();
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(this.dataGridView2_CellClick);
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            txtMenuName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQtyMenu.Text = string.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int menuidValue = Convert.ToInt32(row.Cells["menuid"].Value);
                menuid.Add(menuidValue); // menambahkan menuid ke list

                txtMenuName.Text = row.Cells["name"].Value.ToString();
                txtPrice.Text = row.Cells["price"].Value.ToString();

                string img = row.Cells["photo"].Value.ToString();
                string pathImg = Path.Combine("D:\\LATIHAN LKS 2025 ( DEWA PERMANA P S )\\LKS_2018\\LKS_2018\\Resources", img);

                if (File.Exists(pathImg))
                {
                    pictureBox1.Image?.Dispose(); // dispose gambar yang lama
                    pictureBox1.Image = Image.FromFile(pathImg);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                conn.Open();
                string query = "SELECT name, price, photo, menuid FROM MsMenu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dataGridView1.Columns.Contains("photo"))
                {
                    dataGridView1.Columns["photo"].Visible = false;
                }
                if (dataGridView1.Columns.Contains("menuid"))
                {
                    dataGridView1.Columns["menuid"].Visible = false;
                }
            }
        }

        private void LoadDataorder()
        {
            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                conn.Open();
                string query = "SELECT MsMenu.name, DetailOrder.Qty, DetailOrder.Price " +
                               "FROM MsMenu " +
                               "INNER JOIN DetailOrder ON MsMenu.menuid = DetailOrder.menuid WHERE DetailOrder.Status != 'Done'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // Kelas untuk menyimpan pesanan user
        public class orderUser
        {
            public string namaMenu { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public int menuid { get; set; }
            public decimal total => Quantity * Price;
        }

        // List untuk menyimpan pesanan
        private List<orderUser> List = new List<orderUser>();

        // Tombol Add
        private void AddBtn_Click(object sender, EventArgs e)
        {
            string namaMenu = txtMenuName.Text;
            int menuid = this.menuid.Last(); // mengambil menuid terakhir
            int quantity;
            decimal price;

            // Validasi input Quantity dan Price
            if (!int.TryParse(txtQtyMenu.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please Enter a valid Quantity");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
            {
                MessageBox.Show("Please Enter a valid Price");
                return;
            }

            orderUser orderUser = new orderUser()
            {
                namaMenu = namaMenu,
                menuid = menuid,
                Quantity = quantity,
                Price = price
            };

            List.Add(orderUser);
            LoadDt2();
            total();

            txtMenuName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQtyMenu.Text = string.Empty;
            pictureBox1.Image = null;
        }

        // Menampilkan data ke DataGridView2
        private void LoadDt2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Menu");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Price");
            dt.Columns.Add("Total");

            foreach (var item in List)
            {
                dt.Rows.Add(item.namaMenu, item.Quantity, item.Price, item.total);
            }

            dataGridView2.DataSource = dt;
        }

        // Menghitung total pesanan
        private void total()
        {
            decimal total = List.Sum(item => item.total);
            label5.Text = $"{total:C}";
        }

        // Tombol untuk membuat order baru
        private void ordBtn_Click(object sender, EventArgs e)
        {
            newOrder(); // Membuat order baru di tabel HeaderOrder

            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                conn.Open();

                foreach (var item in List)
                {
                    string query = "INSERT INTO DetailOrder(OrderId, menuid, Qty, Price, Status) " +
                                   "VALUES (@OrderId, @menuid, @Qty, @Price, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", OrderId);
                        cmd.Parameters.AddWithValue("@menuid", item.menuid);
                        cmd.Parameters.AddWithValue("@Qty", item.Quantity);
                        cmd.Parameters.AddWithValue("@Price", item.Price);
                        cmd.Parameters.AddWithValue("@Status", "Pending");

                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }

            List.Clear();
            LoadDt2();
            total();
            MessageBox.Show("Successfully placed the order", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Membuat order baru dan mendapatkan OrderId
        private void newOrder()
        {
            using (SqlConnection conn = new SqlConnection(koneksi))
            {
                string query = "INSERT INTO HeaderOrder (EmployeId, MemberId, Date, Payment, Bank) " +
                               "VALUES (@EmployeId, @MemberId, @Date, @Payment, @Bank); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeId", SessionUser.EmployeId);
                    cmd.Parameters.AddWithValue("@MemberId", SessionUser.MemberId);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Payment", "Cash");
                    cmd.Parameters.AddWithValue("@Bank", "XYZ");

                    conn.Open();
                    OrderId = cmd.ExecuteScalar().ToString(); // mendapatkan OrderId
                    conn.Close();
                }
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void delMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
