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
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBDataSet5.Table_2' table. You can move, or remove it, as needed.
            this.table_2TableAdapter2.Fill(this.dBDataSet5.Table_2);




            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            String query = "SELECT * FROM TABLE_2";
            SqlDataAdapter SDA = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void карточкаЧитателяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void регистрацияЧитателяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chitatel fr3 = new Chitatel();
            fr3.Show();
        }

        

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook fr4 = new AddBook();
            fr4.Show();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           BookUpdate fr5 = new BookUpdate();
           fr5.Show();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookDelete fr6 = new BookDelete();
            fr6.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }

        private void выдатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveBook fr7 = new GiveBook();
            fr7.Show();
        }

        private void выданныеЭкземлярыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookInfo fr8 = new BookInfo();
            fr8.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From TABLE_2 WHERE Наименование LIKE ('" + textBox1.Text +"')";
            cmd.ExecuteNonQuery();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DT);
            dataGridView1.DataSource = DT;
            sqlConnection.Close();
        }
    }
}
