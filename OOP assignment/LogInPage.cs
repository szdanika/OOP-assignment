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
    public partial class LogInPage : Form
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {// moving to the registration form.

            this.Hide();
            RegisterPage regPage = new RegisterPage();
            regPage.ShowDialog();
            this.Close();
        }
    }
}
