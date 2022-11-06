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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            Populate();
          
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Finall;Integrated Security=True;");
        private void Populate()
        {
            Con.Open();
            String query = "select * from Item";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVItem.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void fillcombo()
        {
            // this method will bind the combobox with the Database
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Cat_Name from Category", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Cat_Name", typeof(string));
            dt.Load(rdr);
            Catcb.ValueMember = "Cat_Name";
            Catcb.DataSource = dt;
            Con.Close();
        }
        private void afillingcombo2()
        {
            
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Supp_Name from Supplier", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Supp_Name", typeof(string));
            dt.Load(rdr);
            cbSupp.ValueMember = "Supp_Name";
            cbSupp.DataSource = dt;
            Con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Items it = new Items();
            it.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
       
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
           
           
        }

        private void txtItPrice_TextChanged(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            txtItName.Text = "";
            txtItQty.Text = "";
            txtItPrice.Text = "";
            Catcb.SelectedIndex = -1;
            cbSupp.SelectedIndex = -1;
            key = 0;
        }
        int key = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtItName.Text == "" || txtItQty.Text == "" || txtItPrice.Text == "" || Catcb.SelectedIndex == -1 || cbSupp.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Item values('" + txtItName.Text + "','" + txtItQty.Text + "','" + txtItPrice.Text + "','" + Catcb.SelectedItem + "','" + cbSupp.SelectedItem + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Saved successfully");
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

        private void DGVItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Item To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from Item Where ItId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted successfully");
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtItName.Text == "" || txtItQty.Text == "" || txtItPrice.Text == "" || Catcb.SelectedIndex == -1)
            {
                MessageBox.Show("Select The Employee To Be Updated");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update Item Set ItName='" + txtItName.Text + "',ItQty='" + txtItQty.Text + "',ItPrice='" + txtItPrice.Text + "',ItCat='" + Catcb.SelectedItem.ToString() + "',Supp_Name='" + cbSupp.SelectedItem.ToString() + "' where ItId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Updated successfully");
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

        private void btnReport_Click(object sender, EventArgs e)
        {
           
        }

        private void imgSlide_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderReport_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBillingReport_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {

            Orders or = new Orders();
            or.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
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

        private void DGVItem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtItName.Text = DGVItem.SelectedRows[0].Cells[1].Value.ToString();
            txtItQty.Text = DGVItem.SelectedRows[0].Cells[2].Value.ToString();
            txtItPrice.Text = DGVItem.SelectedRows[0].Cells[3].Value.ToString();
            Catcb.SelectedItem = DGVItem.SelectedRows[0].Cells[4].Value.ToString();
            cbSupp.SelectedItem = DGVItem.SelectedRows[0].Cells[5].Value.ToString();
            if (txtItName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DGVItem.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Catcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Items_Load(object sender, EventArgs e)
        {
            fillcombo();
            afillingcombo2();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
