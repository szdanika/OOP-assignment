using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_assignment
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {// moving to the registration form.

            this.Hide();
            LogInPage logPage = new LogInPage();
            logPage.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Checking and inserting into table
            try
            {
                DatabaseManage dm = new DatabaseManage();;
                string asd = "'nev','email','jelsz'";
                dm.Update();
            }
            catch(IndexOutOfRangeException)
            {

            }
            
        }

        private void CheckData()
        {
            if(textBox1 == null || textBox2 == null || textBox3 == null)
            {
                throw new IndexOutOfRangeException(); // placeholder for the real exception
            }
        }
    }
}
