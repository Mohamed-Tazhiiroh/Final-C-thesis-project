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
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
           
            Populate();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Finall;Integrated Security=True;");
        private void Orders_Load(object sender, EventArgs e)
        {

        }
        private void Populate()
        {
            Con.Open();
            String query = "select * from Orders";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVOrder.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
             txtO_ID.Text = "";
             txtEmp_ID.Text = "";
             txtIt_Name .Text = "";
             txtIt_Qty.Text = "";
            
             txtO_Date.Text = "";
             txtO_ShipDate.Text = "";
                  txtSupp_Name.Text = "";

        }
        private void DGVOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtO_ID.Text =  DGVOrder.SelectedRows[0].Cells[0].Value.ToString();
            txtEmp_ID.Text =  DGVOrder.SelectedRows[0].Cells[1].Value.ToString();
            txtIt_Name.Text =  DGVOrder.SelectedRows[0].Cells[2].Value.ToString();
            txtIt_Qty.Text = DGVOrder.SelectedRows[0].Cells[3].Value.ToString();
            txtSupp_Name.Text =  DGVOrder.SelectedRows[0].Cells[6].Value.ToString();
            txtO_Date.Text =  DGVOrder.SelectedRows[0].Cells[5].Value.ToString();
            txtO_ShipDate.Text =  DGVOrder.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void txtO_Date_TextChanged(object sender, EventArgs e)
        {

        }
         
          
        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtO_ID.Text == "" || txtEmp_ID.Text == "" || txtIt_Name.Text == "" || txtIt_Qty.Text == "" || txtO_Date.Text == "" || txtO_ShipDate.Text == "" || txtSupp_Name.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Orders values('" + txtO_ID.Text + "','" + txtEmp_ID.Text + "','" + txtIt_Name.Text + "','" + txtIt_Qty.Text + "','" + txtO_Date.Text + "','" + txtO_ShipDate.Text + "','" + txtSupp_Name.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Saved successfully");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtO_ID.Text == "")
                {
                    MessageBox.Show("Select Order to delete");
                }
                else
                {
                    Con.Open();
                    string query = "Delete  from Orders where OrderID=" + txtO_ID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Order Deleted succsessfuly");
                    Con.Close();
                    Populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtO_ID.Text == "" || txtEmp_ID.Text == "" || txtIt_Name.Text == "" || txtIt_Qty.Text == "" || txtO_Date.Text == "" || txtO_ShipDate.Text == "" || txtSupp_Name.Text == "")
            {
                MessageBox.Show("Select The Order To Be Updated");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update Orders Set EmpId='" + txtEmp_ID.Text + "',ItName='" + txtIt_Name.Text + "',ItQty='" + txtIt_Qty.Text + "',OrderDate='" + txtO_Date.Text + "',Or_ShipDate='" + txtO_ShipDate.Text + "',Supp_Name='" + txtSupp_Name.Text + "' where OrderID=" + txtO_ID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Updated successfully");
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

        private void btnOrderReport_Click(object sender, EventArgs e)
        {
          
        }

        private void txtSupp_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier supp = new Supplier();
            supp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Billing bl = new Billing();
            bl.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Items it = new Items();
            it.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }

        private void btnBillingReport_Click(object sender, EventArgs e)
        {
        }

        private void txtO_ShipDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Order_Rep rr = new Order_Rep();
            rr.Show();
            this.Hide();
        }
    }
}
