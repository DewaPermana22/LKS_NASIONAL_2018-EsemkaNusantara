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
    public partial class admNav : Form
    {
        public admNav()
        {
            InitializeComponent();
        }

        private void lgBtnAdm_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
            
        }

        private void mngEmploye_Click(object sender, EventArgs e)
        {
            manageEmploye manageEmploye = new manageEmploye();
            manageEmploye.Show();
        }

        private void btnManageMenu_Click(object sender, EventArgs e)
        {
            manageMenu manageMenu = new manageMenu();
            manageMenu.Show();
          
        }

        private void btnManageMember_Click(object sender, EventArgs e)
        {
            FormManageMember manageMember = new FormManageMember();
            manageMember.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormGantiPass formGantiPass = new FormGantiPass();
            formGantiPass.Show();
        }

        private void admNav_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
           FormReport formReport = new FormReport();
            formReport.Show();

        }
    }
}
