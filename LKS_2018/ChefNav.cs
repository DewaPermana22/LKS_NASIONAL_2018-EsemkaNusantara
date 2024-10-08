using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_2018
{
    public partial class ChefNav : Form
    {
        public ChefNav()
        {
            InitializeComponent();
        }

        private void btnLgChef_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormGantiPass gantiPass = new FormGantiPass();
                gantiPass.Show();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           ViewOrder order = new ViewOrder();
            order.Show();
        }
    }
}
