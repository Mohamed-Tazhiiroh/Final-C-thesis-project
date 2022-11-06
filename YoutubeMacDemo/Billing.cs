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
    public partial class Billing : Form
    {
        public Billing()
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
        private void DGVItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        int n = 0, GrdTotal = 0, Amount;
        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || Convert.ToInt32(txtQuantity.Text) > Stock || txtItem.Text == "")
            {
                MessageBox.Show("Enter quantity Or No Enough Quantity");
            }
            else
            {
                int total = Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtPrice.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(DGVBill);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = txtItem.Text;
                newRow.Cells[2].Value = txtPrice.Text;
                newRow.Cells[3].Value = txtQuantity.Text;
                newRow.Cells[4].Value = total;
                DGVBill.Rows.Add(newRow);
                GrdTotal = GrdTotal + total;
                Amount = GrdTotal;
                lblTotal.Text = "" + GrdTotal;
                n++;
                UpdateItem();
                Reset();
            }
        }
        private void Reset()
        {
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtClientName.Text = "";
            txtItem.Text = "";
        }
        private void UpdateItem()
        {

            try
            {
                int newQuantity = Stock - Convert.ToInt32(txtQuantity.Text);
                Con.Open();
                string query = "Update Item Set ItQty=" + newQuantity + " where ItId=" + key + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Updated successfully");
                Con.Close();
                Populate();
                //Clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
      
        private void DGVItem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtClientName.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Bill values('" + lblEmployee.Text + "','" + txtClientName.Text + "'," + Amount + ")", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved successfully");
                    Con.Close();
                    Populate();
                    // Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        string Prodid;
        string Prodname;
        string ProdPrice;
        string ProdQty;
        String Total;
        int pos;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(" Bilan Grocery Shop", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(265, 20));
            e.Graphics.DrawString("ID   PRODUCT     PRICE    QUANTIY    TOTAL", new Font("Century Gothic", 13, FontStyle.Bold), Brushes.Black, new Point(260, 100));
            foreach (DataGridViewRow row in DGVBill.Rows)
            {
                Prodid = "" + row.Cells["Column1"].Value;
                Prodname = "" + row.Cells["Column2"].Value;
                ProdPrice = "" + row.Cells["Column3"].Value;
                ProdQty = "" + row.Cells["Column4"].Value;
                Total = "" + row.Cells["Column5"].Value;
                e.Graphics.DrawString("" + Prodid, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Blue, new Point(260, 140));
                e.Graphics.DrawString("" + Prodname, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Blue, new Point(295, 140));
                e.Graphics.DrawString("" + ProdPrice, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Blue, new Point(420, 140));
                e.Graphics.DrawString("" + ProdQty, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Blue, new Point(500, 140));
                e.Graphics.DrawString("" + Total, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Blue, new Point(587 , 140));
            }
            e.Graphics.DrawString("Xisaabtaadu waa:" + Amount, new Font("Century Gothic", 16, FontStyle.Bold), Brushes.Black, new Point(270, 270));
            e.Graphics.DrawString("invoice Bill print reside", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.Red, new Point(270, 230));
            DGVBill.Rows.Clear();
            DGVBill.Refresh();
            pos = 100;
            Amount = 0;
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            lblEmployee.Text = Login.EmployeeName;
        }

        private void DGVBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCatID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
        {
            if (txtSellerID.Text != "")
            {
                Con.Open();
                string select = "select * from Seller where S_ID=" + txtSellerID.Text + "";
                    SqlCommand cmd = new SqlCommand(select, Con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                   
                        txtClientName.Text = dr.GetValue(1).ToString();



                    }
                    Con.Close();
                }
                else
                {
                    txtClientName.Clear();
                    txtClientName.Clear();
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Billing bl = new Billing();
            bl.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seller sel = new Seller();
            sel.Show();
            this.Hide();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Supplier supp = new Supplier();
            supp.Show();
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

            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Items it = new Items();
            it.Show();
            this.Hide();
        }
        int Stock = 0, key = 0;
        private void DGVItem_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            txtItem.Text = DGVItem.SelectedRows[0].Cells[1].Value.ToString();

            txtPrice.Text = DGVItem.SelectedRows[0].Cells[3].Value.ToString();
           
            if (txtItem.Text == "")
            {
                Stock = 0;
                key = 0;
            }
            else
            {
                Stock = Convert.ToInt32(DGVItem.SelectedRows[0].Cells[2].Value.ToString());
                key = Convert.ToInt32(DGVItem.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        
    }
}
