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
    public partial class chitatelDelete : Form
    {
        private SqlConnection sqlConnection;
        public chitatelDelete()
        {
            InitializeComponent();
        }

        private void chitatelDelete_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Visible)
                label2.Visible = false;
            sqlConnection.Open();
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                String query = "DELETE FROM READERS  WHERE Имя = '" + textBox1.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, sqlConnection);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Читатель удален");
                Close();
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Поле имя должно быть заполненным";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Close();
        }
    }
}
