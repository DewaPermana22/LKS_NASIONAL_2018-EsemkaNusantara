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
    public partial class FormReport : Form
    {
        string connection = "Data Source=RPLSMKN8JBR\\SQLEXPRESS;Initial Catalog=LKS_2018;Integrated Security=True;";
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private DataTable dt;
        public FormReport()
        {
            InitializeComponent();
            string[] Bulan = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            cmbFrom.Items.AddRange(Bulan);
            cmbTo.Items.AddRange(Bulan);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int FromMonth = cmbFrom.SelectedIndex + 1;
            int ToMonth = cmbTo.SelectedIndex + 1;

            conn = new SqlConnection(connection);
            cmd = new SqlCommand(@"SELECT FORMAT(HeaderOrder.Date, 'MMMM') AS Month,
                                   SUM(DetailOrder.Qty * DetailOrder.Price) AS Income 
                                   FROM HeaderOrder JOIN DetailOrder ON HeaderOrder.OrderId = DetailOrder.Orderid
                                   WHERE MONTH(HeaderOrder.Date) BETWEEN @FromMonth AND @ToMonth
                                   GROUP BY FORMAT(HeaderOrder.Date, 'MMMM'), MONTH(HeaderOrder.Date)
                                   ORDER BY MONTH(HeaderOrder.Date);", conn);
            cmd.Parameters.AddWithValue("@FromMonth", FromMonth);
            cmd.Parameters.AddWithValue("@ToMonth", ToMonth);
            conn.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (chart1.Series.IsUniqueName("Income"))
            {
                chart1.Series.Add("Income");
            }
            chart1.Titles.Add("Income In Milion");
            chart1.Series["Income"].Points.Clear();
            chart1.Series["Income"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column; // Contoh tipe chart

            foreach (DataRow row in dt.Rows)
            {
                chart1.Series["Income"].Points.AddXY(row["Month"].ToString(), row["Income"]);
            }
        }
    }
}
