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
    public partial class Chitatel : Form
    {
        private SqlConnection sqlConnection;
        public Chitatel()
        {
            InitializeComponent();
        }
        private void Chitatel_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-8U3BM7L\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            label7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
            sqlConnection.Open();
            String query = "INSERT INTO READERS([Номер билета], Имя, Фамилия, Телефон, [Дата рождения], Адрес) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox4.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, sqlConnection);
            SDA.SelectCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Читатель добавлен");
            Close();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поле Номер билета, Имя и Адрес должны быть заполнены";
            }
        }
    }
}
