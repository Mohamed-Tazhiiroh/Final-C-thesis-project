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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
            Populate();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Finall;Integrated Security=True;");
        private void Populate()
        {
            Con.Open();
            String query = "select * from Supplier";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVSupplier.DataSource = ds.Tables[0];
            Con.Close();
        }
           private void Clear()
        {
            txtS_Name.Text = "";
            txtS_Country.Text = "";
            txtS_Email.Text = "";
            txtS_Phone.Text = "";
            txtS_Package.Text = "";
            txtItCat.Text = "";
            key = 0;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            Seller sel = new Seller();
            sel.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
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

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtS_Name.Text == "" || txtS_Country.Text == "" || txtS_Email.Text == "" || txtS_Phone.Text == "" || txtS_Package.Text == "" || txtItCat.Text == "" )
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Supplier values('" + txtS_Name.Text + "','" + txtS_Country.Text + "','" + txtS_Email.Text + "','" + txtS_Phone.Text + "','" + txtS_Package.Text + "','" + txtItCat.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier Saved successfully");
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
            if (txtS_Name.Text == "" || txtS_Country.Text == "" || txtS_Email.Text == "" || txtS_Phone.Text == "" || txtS_Package.Text == "" || txtItCat.Text == "")
            {
                MessageBox.Show("Select The Supplier To Be Updated");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update Supplier Set Supp_Name='" + txtS_Name.Text + "',Supp_country='" + txtS_Country.Text + "',Supp_Email='" + txtS_Email.Text + "',Supp_Phone='" + txtS_Phone.Text + "',Supp_Package='" + txtS_Package.Text + "' ,ItCat='" + txtItCat.Text + "' where SupplierID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier Updated successfully");
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
        
        private void DGVSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Supplier To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from Supplier Where SupplierID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier Deleted successfully");
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
        private void DGVSupplier_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtS_Name.Text = DGVSupplier.SelectedRows[0].Cells[1].Value.ToString();
            txtS_Country.Text = DGVSupplier.SelectedRows[0].Cells[2].Value.ToString();
            txtS_Email.Text = DGVSupplier.SelectedRows[0].Cells[3].Value.ToString();
            txtS_Phone.Text = DGVSupplier.SelectedRows[0].Cells[4].Value.ToString();
            txtS_Package.Text = DGVSupplier.SelectedRows[0].Cells[5].Value.ToString();
            txtItCat.Text = DGVSupplier.SelectedRows[0].Cells[6].Value.ToString();
            if (txtS_Name.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DGVSupplier.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void txtItCat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
