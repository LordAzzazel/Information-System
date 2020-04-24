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
    public partial class BookUpdate : Form
    {
        private SqlConnection sqlConnection;
        public BookUpdate()
        {
            InitializeComponent();
        }
        private void BookUpdate_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-8U3BM7L\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            label7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)){
                sqlConnection.Open();
                String query = "UPDATE TABLE_2 SET Наименование = '" + textBox2.Text + "',Автор = '" + textBox4.Text + "',Год ='" + textBox5.Text + "', Количество ='" + textBox6.Text + "', Издательство = '" + textBox3.Text + "'WHERE Id = '" + textBox1.Text + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, sqlConnection);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Inserted Succsesfuly");
                Close();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поле № должно быть заполнено";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Close();
        }

        
    }
}
