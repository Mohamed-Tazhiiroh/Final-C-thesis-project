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
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string User, Pass;
            User = txtAdminName.Text;
            Pass = txtAdminpass.Text;
            if(User=="Ayaanle"&& Pass=="7410")
            {
                Form1 fm = new Form1();
                fm.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("user or Password incorect");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void txtAdminpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
