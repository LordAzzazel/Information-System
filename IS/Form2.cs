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

namespace IS
{
    public partial class Form2 : Form
    {
        private SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBDataSet2.Readers' table. You can move, or remove it, as needed.
            this.readersTableAdapter.Fill(this.dBDataSet2.Readers);
            string connectionString = @"Data Source=DESKTOP-8U3BM7L\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            String query = "SELECT * FROM READERS";
            SqlDataAdapter SDA = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            MessageBox.Show("Something changed");
        }
    }
}
