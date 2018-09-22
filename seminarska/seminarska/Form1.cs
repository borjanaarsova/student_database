using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace seminarska
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PassTextBox.PasswordChar='*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand("select * from databaza.admin where korisnicko_ime='" + this.UserTextBox.Text + "' and lozinka='" + this.PassTextBox.Text + "' ;", MyConn);
                MySqlDataReader MyReader;

                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                int count = 0;
                while (MyReader.Read())
                {
                    Console.WriteLine(MyReader[count]);
                    count++;
                }
                Form2 f2 = new Form2();
                if (count == 1)
                {
                    MessageBox.Show("Podatocite se tocni.");
                    this.Hide();

                    f2.ShowDialog();
                }
                else if (count > 1)
                {

                    MessageBox.Show("Korisnickoto ime i lozinka se povtoruvaat vo bazata.\nOdbien pristap.");
                }
                else
                {
                    MessageBox.Show("Korisnickoto ime ili lozinka se pogresni.\nObidi se povtorno.");
                }
                MyConn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
       
    }
}
