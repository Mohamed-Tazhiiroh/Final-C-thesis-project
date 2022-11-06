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

namespace YoutubeMacDemo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static String EmployeeName = "";
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Final;Integrated Security=True;");
        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Employee where EmpName='" + txtUserName.Text + "' and EmpPass='" + txtPassword.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                EmployeeName = txtUserName.Text;
               
                Seller sel = new Seller();
                sel.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Wrong UserName Or Password");
            }
            Con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Adminlogin ad = new Adminlogin();
            ad.Show();
            this.Hide();
        }
    }
}
