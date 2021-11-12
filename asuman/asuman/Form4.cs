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
    public partial class Form4 : Form
    {
        public string connString;
        public string query, query2;
        public SqlDataAdapter dAdapter, dAdapter2;
        public DataTable dTable;
        public SqlCommandBuilder cBuilder;
        public DataView myDataview, dTableSchema_dv;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            {
                connString = "Provider=SQLNCLI11;Data Source=LAB03\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=sirket";
                query = "SELECT* From Personel";
                dAdapter = new SqlDataAdapter(query, connString);
                dTable = new DataTable();
                cBuilder = new SqlCommandBuilder(dAdapter);
                
                myDataview = dTable.DefaultView;
                dAdapter.Fill(dTable);
                //dataGridView1.DataSource = dTable;

                BindingSource bndSource = new BindingSource();
                bndSource.DataSource = dTable;
                this.dataGridView1.DataSource = bndSource;

                for (int q = 0; q <= dataGridView1.ColumnCount - 1; q++)
                {
                    this.comboBox1.Items.Add(this.dataGridView1.Columns[q].HeaderText.ToString());
                }
                SqlConnection dbConn = new SqlConnection(connString);
                dbConn.Open();
                DataTable dTableSchema = dbConn.GetSchema("tables");
                dataGridView2.DataSource = dTableSchema;
                dTableSchema_dv = dTableSchema.DefaultView;

            }
        }
    }
}
