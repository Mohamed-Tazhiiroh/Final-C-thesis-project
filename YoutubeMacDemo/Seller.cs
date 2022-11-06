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
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
            Populate();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Finall;Integrated Security=True;");
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void Populate()
        {
            Con.Open();
            String query = "select * from Seller";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DgvSeller.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            txtS_ID.Text = "";
            txtSNAME.Text = "";
            txtSAddress.Text = "";
            txtSCity.Text = "";
            txtSPhone.Text = "";
           
        }
        
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtS_ID.Text == "")
                {
                    MessageBox.Show("Select Seller to delete");
                }
                else
                {
                    Con.Open();
                    string query = "Delete  from Seller where S_ID=" + txtS_ID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Seller Deleted succsessfuly");
                    Con.Close();
                    Populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtS_ID.Text == "" ||txtSNAME.Text == "" || txtSAddress.Text == "" || txtSCity.Text == "" || txtSPhone.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Seller values('" + txtS_ID.Text + "','" + txtSNAME.Text + "','" + txtSAddress.Text + "','" + txtSCity.Text + "','" + txtSPhone.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Saved successfully");
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
            if (txtS_ID.Text == "" || txtSNAME.Text == "" || txtSAddress.Text == "" || txtSCity.Text == "" || txtSPhone.Text == "")
            {
                MessageBox.Show("Select The Seller To Be Updated");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update Seller Set S_Name='" + txtSNAME.Text  + "',S_Address='" + txtSAddress.Text + "',S_City='" + txtSCity.Text + "',S_Phone='" + txtSPhone.Text + "' where S_ID=" + txtS_ID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Updated successfully");
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Supplier supp = new Supplier();
            supp.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Billing bl = new Billing();
            bl.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {
            Orders or = new Orders();
            or.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Cus_Rep rep = new Cus_Rep();
            rep.Show();
            this.Hide();
        }

        private void btnBillingReport_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnOrderReport_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }
       
        private void DGVSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtS_ID.Text = DgvSeller.SelectedRows[0].Cells[0].Value.ToString();
            txtSNAME.Text = DgvSeller.SelectedRows[0].Cells[1].Value.ToString();
            txtSAddress.Text = DgvSeller.SelectedRows[0].Cells[2].Value.ToString();
            txtSCity.Text = DgvSeller.SelectedRows[0].Cells[3].Value.ToString();
            txtSPhone.Text = DgvSeller.SelectedRows[0].Cells[4].Value.ToString();
            
        }

        private void txtS_ID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
