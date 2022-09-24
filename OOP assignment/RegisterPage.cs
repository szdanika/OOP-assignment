
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
using DatabaseManager;

namespace OOP_assignment
{
    public partial class RegisterPage : SuperClass
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ChangePage(new LogInPage(), this);
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
            catch(Exception exc) when ( exc is AlreadyUsedUsernameException || exc is InformationIsNotFilledException)
            {
                label5.Text = exc.Message;
                label5.Visible = true;
            }
            
        }

        private void CheckData()
        {
            DatabaseManage dm = new DatabaseManage();
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                throw new InformationIsNotFilledException();
            if (dm.IsItUsed(textBox1.Text,Records.name))
                throw new AlreadyUsedUsernameException();
            if(dm.IsItUsed(textBox2.Text,Records.email))
                throw new AlreadyUsedUsernameException();
        }
    }
}
