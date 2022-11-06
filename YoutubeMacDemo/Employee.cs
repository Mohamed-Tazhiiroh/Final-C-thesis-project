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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
             Populate();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Final;Integrated Security=True;");
        private void Populate()
        {
            Con.Open();
            String query = "select * from Employee";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVEmployees.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
         private void Clear()
        {
            txtEmpName.Text = "";
            txtEmpPassword.Text = "";
            txtEmpPhone.Text = "";
            txtEmpAddress.Text = "";
            key = 0;
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Items it = new Items();
            it.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void imgSlide_Click(object sender, EventArgs e)
        {

        }

        private void imgSlide_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmpName.Text == "" || txtEmpPhone.Text == "" || txtEmpAddress.Text == "" || txtEmpPassword.Text == "" || txtEmpSalary.Text == "" || txtEmpRole.Text == "")
            {
                MessageBox.Show("Missing information");
            }else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Employee values('" + txtEmpName.Text + "','" + txtEmpPhone.Text + "','" + txtEmpAddress.Text + "','" + txtEmpPassword.Text + "','" + txtEmpSalary.Text + "','" + txtEmpRole.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved successfully");
                    Con.Close();
                    Populate();
                    Clear();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtEmpName.Text == "" || txtEmpPhone.Text == "" || txtEmpAddress.Text == "" || txtEmpPassword.Text == "" || txtEmpSalary.Text == "" || txtEmpRole.Text == "")
            {
                MessageBox.Show("Select The Employee To Be Updated");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update Employee Set EmpName='" + txtEmpName.Text + "',EmpPhone='" + txtEmpPhone.Text + "',EmpAdd='" + txtEmpAddress.Text + "',EmpPass='" + txtEmpPassword.Text + "',EmpSalary='" + txtEmpSalary.Text + "',EmpRole ='" + txtEmpRole.Text + "' where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated successfully");
                    Con.Close();
                    Populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
       
        private void DGVEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             if (key == 0)
            {
                MessageBox.Show("Select The Employee To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from Employee Where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted successfully");
                    Con.Close();
                    Populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Billing bl = new Billing();
            bl.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Supplier supp = new Supplier();
            supp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Items it = new Items();
            it.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Orders or = new Orders();
            or.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBillingReport_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOrderReport_Click(object sender, EventArgs e)
        {
          
           
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Seller sel = new Seller();
            sel.Show();
            this.Hide();
        }
        int key = 0;
        private void DGVSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtEmpName.Text = DGVEmployees.SelectedRows[0].Cells[1].Value.ToString();
            txtEmpPhone.Text = DGVEmployees.SelectedRows[0].Cells[2].Value.ToString();
            txtEmpAddress.Text = DGVEmployees.SelectedRows[0].Cells[3].Value.ToString();
            txtEmpPassword.Text = DGVEmployees.SelectedRows[0].Cells[4].Value.ToString();
            txtEmpSalary.Text = DGVEmployees.SelectedRows[0].Cells[5].Value.ToString();
            txtEmpRole.Text = DGVEmployees.SelectedRows[0].Cells[6].Value.ToString();
            if (txtEmpName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DGVEmployees.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
