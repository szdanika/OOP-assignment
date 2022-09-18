using OOP_assignment.Exceptions;
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
    public partial class RegisterPage : SuperClass
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
                DatabaseManage dm = new DatabaseManage();
                CheckData();
                string data = "'"+textBox1.Text + "','"+textBox2.Text + "','"+textBox3.Text + "'";
                dm.Insert(Tables.info, data);
                ChangePage(new LogInPage(), this);
            }
            catch(InformationIsNotFilledException exc)
            {
                label5.Text = exc.Message;
                label5.Visible = true;
            }
            
        }

        private void CheckData()
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                throw new Exceptions.InformationIsNotFilledException();
        }
    }
}
