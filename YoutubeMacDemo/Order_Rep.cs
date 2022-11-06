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
    public partial class Order_Rep : Form
    {
        public Order_Rep()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ALJ2AAE;Initial Catalog=Finall;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string select = "select * from Orders where OrderID='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(select, Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Con.Close();
                CrystalReport1 cr = new CrystalReport1();
                cr.Database.Tables["Orders"].SetDataSource(dt);
                this.crystalReportViewer1.ReportSource = cr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                string select = "select * from Orders where Supp_Name='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(select, Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Con.Close();
                CrystalReport1 cr = new CrystalReport1();
                cr.Database.Tables["Orders"].SetDataSource(dt);
                this.crystalReportViewer1.ReportSource = cr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                Con.Open();
                string select = "select * from Orders where Or_ShipDate between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                SqlCommand cmd = new SqlCommand(select, Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Con.Close();
                CrystalReport1 cr = new CrystalReport1();
                cr.Database.Tables["Orders"].SetDataSource(dt);
                this.crystalReportViewer1.ReportSource = cr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Orders or = new Orders();
            or.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Show();
                textBox1.Show();
                textBox2.Hide();
                button1.Show();
                button2.Hide();
                button3.Hide();
                dateTimePicker1.Hide();
                dateTimePicker2.Hide();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label1.Hide();
                label2.Show();
                label3.Hide();
                label4.Hide();
                label5.Show();
                textBox1.Hide();
                textBox2.Show();
                button1.Hide();
                button2.Show();
                button3.Hide();
                dateTimePicker1.Hide();
                dateTimePicker2.Hide();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label1.Hide();
                label2.Hide();
                label3.Show();
                label4.Show();
                label5.Show();
                textBox1.Hide();
                textBox2.Hide();
                button1.Hide();
                button2.Hide();
                button3.Show();
                dateTimePicker1.Show();
                dateTimePicker2.Show();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
