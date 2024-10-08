using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_2018
{
    public partial class Payment : Form
    {

        string connection = "Data Source=RPLSMKN8JBR\\SQLEXPRESS;Initial Catalog=LKS_2018;Integrated Security=True;";
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        public Payment()
        {
            conn = new SqlConnection(connection);
            InitializeComponent();
            cmbPay.Items.Add("Bank");
            cmbPay.Items.Add("Cash");

            cmbBankName.Items.Add("BNI");
            cmbBankName.Items.Add("BRI");
            cmbBankName.Items.Add("MANDIRI");
            cmbBankName.Items.Add("BCA");

            cmbBankName.SelectedIndexChanged += cmbBankName_SelectedIndexChanged;
            cmbPay.SelectedIndexChanged += cmbPay_SelectedIndexChanged;

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillId();
            dataGridView1.ReadOnly = true;
            txtCardNum.Enabled = false;
            cmbBankName.Enabled = false;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cmbId.SelectedValue != null)
            {
             DataRowView dr = cmbId.SelectedItem as DataRowView;

                if (dr != null)
                {
                    int id = Convert.ToInt32(dr["OrderId"]);
                    idTerpilih(id);
                }
            }
        }

        private void FillId()
        {
            cmd = new SqlCommand("SELECT DISTINCT OrderId FROM DetailOrder WHERE Status != 'Done' ",conn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbId.DataSource = dt;
            cmbId.DisplayMember = "OrderId";
            cmbId.ValueMember = "OrderId";
        }


        private void idTerpilih(int OrderId)
        {

            cmd = new SqlCommand(@"SELECT MsMenu.name,  DetailOrder.Qty, DetailOrder.Price 
                                 FROM DetailOrder INNER JOIN MsMenu ON DetailOrder.menuid = MsMenu.menuid 
                                 WHERE DetailOrder.OrderId = @OrderId", conn);
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("Total", typeof(decimal));

            foreach (DataRow row in dt.Rows)
            {
                decimal qty = Convert.ToDecimal(row["Qty"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                row["Total"] = qty * price;
            }
            {
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            labelTotal();
        }

        private void cmbPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pilihMethod = cmbPay.SelectedItem.ToString();

            if (pilihMethod == null)
            {
                MessageBox.Show("Pilih Metode Pembayaran!", "Warning!",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

            if (pilihMethod != "Cash")
            {
                txtCardNum.Enabled = true;
                cmbBankName.Enabled = true;
            }
            else
            {
                cmbBankName.Enabled = false;
                txtCardNum.Enabled = false;
            }

        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
             
        }

        private void labelTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }

            label3.Text = "Total : " + total.ToString("N2");
        }

        private void btnSv_Click(object sender, EventArgs e)
        {

            if (cmbPay.SelectedItem == null)
            {
                MessageBox.Show("Please Eenter Payment Method!");
                return;
            }
            string kondSv = cmbPay.SelectedItem.ToString();
            DataRowView dataRowView = cmbId.SelectedItem as DataRowView;
            string idNampak = dataRowView["OrderId"].ToString();

            if (kondSv == "Cash")
            {
                cashOrd();
                sudahSelesai();
                cmbId.Items.Remove(idNampak);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                UbahStatus();
                FillId();
                kondisiAwal();
            } else
            {
                CreditCard();
                cmbId.Items.Remove(idNampak);
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                UbahStatus();
                FillId();
                kondisiAwal();
            }
            

        }

        private void CreditCard()
        {
            
            cmd = new SqlCommand("UPDATE HeaderOrder SET Bank = @Bank, Date = @Date, Payment = @Payment WHERE OrderId = @OrderId", conn);
            cmd.Parameters.AddWithValue("@Bank", cmbBankName.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
            cmd.Parameters.AddWithValue("Payment", "Credit Card");
            cmd.Parameters.AddWithValue("@OrderId", Convert.ToInt32(cmbId.SelectedValue));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Berhasil Melakukan Pembayaran");
        }

        private void cashOrd()
        {

            DataRowView row = cmbId.SelectedItem as DataRowView;
            int Id = Convert.ToInt32(row["OrderId"]);
            cmd = new SqlCommand("UPDATE HeaderOrder SET Bank = @Bank, Date = @Date, Payment = @Payment WHERE OrderId = @OrderId", conn);
            cmd.Parameters.AddWithValue("@Bank", "-");
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
            cmd.Parameters.AddWithValue("@Payment", "Cash");
            cmd.Parameters.AddWithValue("@OrderId", Id);
            conn.Open() ;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Berhasil Melakukan Pembayaran!");
        }


        private void sudahSelesai()
        {
            cmd = new SqlCommand("UPDATE HeaderOrder SET Message = 1 WHERE OrderId = @OrderId",conn);
            cmd.Parameters.AddWithValue("@orderId", Convert.ToInt32(cmbId.SelectedValue));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void UbahStatus()
        {
            cmd = new SqlCommand("UPDATE DetailOrder SET Status = 'Done' WHERE OrderId = @OrderId", conn);
            cmd.Parameters.AddWithValue("@orderId", Convert.ToInt32(cmbId.SelectedValue));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void kondisiAwal()
        {
            cmbBankName.SelectedIndex = 0;
            txtCardNum.Text = string.Empty;
            cmbPay.SelectedIndex = 0;
        }
    }
}
