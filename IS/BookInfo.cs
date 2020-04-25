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
    public partial class BookInfo : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True");

        public BookInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            String query = "SELECT * FROM BOOK";
            SqlDataAdapter SDA = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void BookInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBDataSet6.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.dBDataSet6.Book);
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "Select";
            chkbox.Width = 25;
            chkbox.Name = "DGVchkBox";
            dataGridView1.Columns.Insert(0, chkbox);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                bool chkboxselect = Convert.ToBoolean(item.Cells["DGVchkBox"].Value);
                if (chkboxselect)
                {
                    sqlConnection.Open();
                    string query2 = "DELETE FROM BOOK WHERE [Имя] = '" + item.Cells[1].Value.ToString() + "'";
                    SqlDataAdapter SDAA = new SqlDataAdapter(query2, sqlConnection);
                    SDAA.SelectCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            MessageBox.Show("Книга возвращена");
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From BOOK WHERE Имя LIKE ('" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DT);
            dataGridView1.DataSource = DT;
            sqlConnection.Close();
        }
    }
}
