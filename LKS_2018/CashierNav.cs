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
    public partial class CashierNav : Form
    {
        public CashierNav()
        {
            InitializeComponent();
        }

        private void PaymentBtn_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.ShowDialog();
            this.Close();
        }

        private void chgPw_Click(object sender, EventArgs e)
        {
            FormGantiPass formGantiPass = new FormGantiPass();
            formGantiPass.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.ShowDialog();
            this.Close();
        }
    }
}
