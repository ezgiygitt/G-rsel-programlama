using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asuman
{
    public partial class Form5 : Form
    {
        int i = 0;
        DataSet ds = new DataSet();
        SqlConnection sqlConn = new SqlConnection();
        SqlDataAdapter oadaptor;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Data Source =LAB03\\SQLEXPRESS;  Initial Catalog = sirket; Integrated Security = True";

            try
            {
                oadaptor = new SqlDataAdapter("SELECT * FROM sertifika", sqlConn);
                oadaptor.Fill(ds);
                //sqlConn.Close();

                dataGridView1.DataSource = ds.Tables[0];
                sqlConn.Open();
                textBox6.Text = ds.Tables[0].Rows[0] ["p_no"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0] ["s_name"].ToString();
                textBox4.Text = ds.Tables[0].Rows[0] ["s_subject"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection();
                sqlConn.ConnectionString = "Data Source =LAB03\\SQLEXPRESS;  Initial Catalog = sirket; Integrated Security = True";

                sqlConn.Open();
                using (SqlCommand command = new SqlCommand(
                    "CREATE TABLE sertifika (sert_no INT IDENTITY(1,1) NOT NULL, p_no INT, s_name varchar(25), s_subject varchar(25))", sqlConn))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tablo Eklendi!");

                    SqlDataAdapter oadaptor2 = new SqlDataAdapter("SELECT * FROM sertifika", sqlConn);
                    DataSet ds = new DataSet();

                    oadaptor2.Fill(ds);

                    //sqlConn.Close();

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch
            {
                MessageBox.Show("Bağlantı kurulamadı!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "Data Source =LAB03\\SQLEXPRESS;  Initial Catalog = sirket; Integrated Security = True";
            sqlConn.Open();
            using (SqlCommand command = new SqlCommand(
                "INSERT INTO sertifika VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "')", sqlConn))
            {
                command.ExecuteNonQuery();

                SqlDataAdapter oadaptor2 = new SqlDataAdapter("SELECT * FROM sertifika", sqlConn);
                DataSet ds = new DataSet();

                oadaptor2.Fill(ds);

                //sqlConn.Close();

                dataGridView1.DataSource = ds.Tables[0];
            }       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection();
                sqlConn.ConnectionString = "Data Source =LAB03\\SQLEXPRESS;  Initial Catalog = sirket; Integrated Security = True";

                sqlConn.Open();
                using (SqlCommand command = new SqlCommand(
                    "DROP TABLE sertifika", sqlConn))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tablo Silindi!");

                    SqlDataAdapter oadaptor2 = new SqlDataAdapter("SELECT * FROM sertifika", sqlConn);
                    //DataSet ds = new DataSet();

                    oadaptor2.Fill(ds);

                    //sqlConn.Close();

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch 
            {
                MessageBox.Show("Bağlantı Kurulamadı!");
                dataGridView1.DataSource = null;
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (i < ds.Tables[0].Rows.Count -1)
            {
                i++;
                textBox6.Text = ds.Tables[0].Rows[i]["p_no"].ToString();
                textBox5.Text = ds.Tables[0].Rows[i]["s_name"].ToString();
                textBox4.Text = ds.Tables[0].Rows[i]["s_subject"].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i == ds.Tables[0].Rows.Count - 1 || i !=0)
            {
                i--;
                textBox6.Text = ds.Tables[0].Rows[i]["p_no"].ToString();
                textBox5.Text = ds.Tables[0].Rows[i]["s_name"].ToString();
                textBox4.Text = ds.Tables[0].Rows[i]["s_subject"].ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            oadaptor.Update(ds.Tables["Sertifika"]);
        }
    }
}
