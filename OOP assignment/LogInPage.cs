using OOP_assignment.Exceptions;
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
    public partial class LogInPage : SuperClass
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {// moving to the registration form.

            ChangePage(new RegisterPage(), this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UserInformation.UserId = CheckInformation();
                ChangePage(new MainPage(), this);
            }
            catch(Exception  exc) when (exc is InformationIsNotFilledException || exc is IncorrectInformationException)
            {
                label4.Text = exc.Message;
                label4.Visible = true;
            }
        }
        private int CheckInformation()
        {
            DatabaseManage dm = new DatabaseManage();
            //Check if the fields are filled
            if (textBox1.Text == "" || textBox2.Text == "")
                throw new InformationIsNotFilledException();

            //check if the information is correct
            int id = dm.Login(textBox1.Text, textBox2.Text);
            if (id == 0)
                throw new IncorrectInformationException();

            return id;

        }
    }
}
