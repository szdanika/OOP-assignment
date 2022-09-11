using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            DatabaseManage dm = new DatabaseManage();;
            string asd = "nev,email,jelsz";
            dm.Insert(tables.info, asd);
        }
    }
}
