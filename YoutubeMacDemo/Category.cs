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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Finall;Integrated Security=True;");
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            populate();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from Category";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                string query = "insert into Category values(" + txtCatID.Text + ",'" + txtCatName.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" category added succsessfuly");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CatDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCatID.Text == "")
                {
                    MessageBox.Show("Select category to delete");
                }
                else
                {
                    Con.Open();
                    string query = "Delete  from Category where Cat_ID=" + txtCatID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" category Deleted succsessfuly");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCatID.Text == "" || txtCatName.Text == "" )
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "Update Category set Cat_Name='" + txtCatName.Text + "' where Cat_ID=" + txtCatID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" category Updated succsessfuly");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
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
            emp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seller sel = new Seller();
            sel.Show();
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

        private void btnReports_Click(object sender, EventArgs e)
        {
            btnReportss.Visible = true;
        }

        private void btnBillingReport_Click(object sender, EventArgs e)
        {
            btnReportss.Visible = false;
        }

        private void btnOrderReport_Click(object sender, EventArgs e)
        {
            btnReportss.Visible = false;
            Order_Rep rep = new Order_Rep();
            rep.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void CatDgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtCatID.Text = CatDgv.SelectedRows[0].Cells[0].Value.ToString();
            txtCatName.Text = CatDgv.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void txtCatID_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
