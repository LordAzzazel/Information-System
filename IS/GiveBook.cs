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
    public partial class GiveBook : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True");
        public GiveBook()
        {
            InitializeComponent();
        }

        private void GiveBook_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Наименование FROM TABLE_2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Наименование"].ToString());
            }
            comboBox2.Items.Clear();
            SqlCommand query = sqlConnection.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT Имя FROM READERS";
            query.ExecuteNonQuery();
            DataTable dtb = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(query);
            dap.Fill(dtb);
            foreach (DataRow dr in dtb.Rows)
            {
                comboBox2.Items.Add(dr["Имя"].ToString());
            }
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            String query2 = "INSERT INTO BOOK(Имя, Книга, [Дата сдачи]) Values('" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Value + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query2, sqlConnection);
            SDA.SelectCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Книга выдана");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Close();
        }
    }
}
