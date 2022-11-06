using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeMacDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
        }

        private void moveImageBox(object sender)
        {
           

            
        }


        private void addUserControl(UserControl uc)
        {
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            panelContainer.Controls.Add(uc);
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
          
            moveImageBox(sender);
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
        }

        private void imgSlide_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seller sel = new Seller();
            sel.Show();
            this.Hide();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier supp = new Supplier();
            supp.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Billing bl = new Billing();
            bl.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Orders or = new Orders();
            or.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Items it = new Items();
            it.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

            btnReportss.Visible = true;
        }

        private void btnBillingReport_Click(object sender, EventArgs e)
        {
            btnReportss.Visible = false;
            Cus_Rep cc = new Cus_Rep();
            cc.Show();
        }

        private void btnOrderReport_Click(object sender, EventArgs e)
        {
            btnReportss.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }

        private void guna2CustomGradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
