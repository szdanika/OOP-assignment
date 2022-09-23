using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseManager;

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
                DatabaseManager.DatabaseManage dm = new DatabaseManager.DatabaseManage();
                UserInformation.UserId = dm.Login(textBox1.Text, textBox2.Text); //CheckInformation();
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
            //DatabaseManager.DatabaseManage dm = new DatabaseManager.DatabaseManage();
            //Check if the fields are filled
            if (textBox1.Text == "" || textBox2.Text == "")
                throw new InformationIsNotFilledException();

            //check if the information is correct
            return dm.Login(textBox1.Text, textBox2.Text); 

        }
    }
}
