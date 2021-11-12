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

namespace asuman
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;
        SqlDataAdapter veriadaptor;
        SqlCommand komut;
        DataSet veriset;
        void griddoldur()
        {
            baglanti = new SqlConnection("Data Source=LAB03\\SQLEXPRESS;Initial Catalog=sirket;Integrated Security=True");
            veriadaptor = new SqlDataAdapter("SELECT * FROM personel", baglanti);
            veriset = new DataSet();
            baglanti.Open();
            veriadaptor.Fill(veriset, "personel");
            dataGridView1.DataSource = veriset.Tables["personel"];
            baglanti.Close();
        }

            private void Form2_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from personel where personel_no=" + textBox1.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update personel set ad='" + textBox2.Text + "' where personel_no="+textBox1.Text +"";
            komut.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into personel values ('" + textBox3.Text + "','" + textBox4.Text+  "','"+comboBox1.Text+"','1985.03.25',"+textBox5.Text+",'1985.03.25',"+textBox6.Text+","+textBox7.Text+","+textBox8.Text+","+textBox9.Text+","+textBox10.Text+")";
            komut.ExecuteNonQuery();
            baglanti.Close();
            griddoldur();
        }
    }
}
