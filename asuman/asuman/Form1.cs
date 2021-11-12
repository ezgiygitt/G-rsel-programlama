using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace asuman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oleDbConnectionString = "Provider=SQLNCLI11;Data Source=LAB03\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=sirket";
            OleDbConnection oleDbConn = new OleDbConnection(oleDbConnectionString);
            try
            {
                OleDbDataAdapter sqlCommand = new OleDbDataAdapter("SELECT * FROM personel", oleDbConn);
                DataTable oleDbTable = new DataTable();

                oleDbConn.Open();
                MessageBox.Show("Bağlantı kuruldu!");
                sqlCommand.Fill(oleDbTable);

                oleDbConn.Close();

                dataGridView1.DataSource = oleDbTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "Data Source =LAB03\\SQLEXPRESS;  Initial Catalog = sirket; Integrated Security = True";


            //string sqlConnetionString = null;
            //sqlConnetionString = "Data Source = FURKAN\\SQLEXPRESS; Initial Catalog = sirket; Integrated Security = True";
            //SqlConnection sqlConn2 = new SqlConnection(connetionString);
            try
            {
                SqlDataAdapter oadaptor = new SqlDataAdapter("SELECT * FROM proje", sqlConn);
                DataSet ds = new DataSet();

                sqlConn.Open();
                MessageBox.Show("Bağlantı kuruldu!");
                oadaptor.Fill(ds);

                sqlConn.Close();

                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
