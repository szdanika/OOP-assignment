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
using DatabaseManage;

namespace OOP_assignment
{
    public partial class ProfilPage : SuperClass 
    {
        public int PId { get; set; }
        public ProfilPage()
        {
            InitializeComponent();
            GettingInformation();
        }
        public void GettingInformation()
        {
            DatabaseManage dm = new DatabaseManage();
            string select = "SELECT PlayerName, PlayerEmail, PlayerPassword ", where = " WHERE PlayerId = '" + UserInformation.UserId + "'";
            DataTable dt = dm.Select(select, Tables.info, where, "","");
            DataRow dr = dt.Rows[0];
            textBox1.Text = dr["PlayerName"].ToString();
            textBox2.Text = dr["PlayerEmail"].ToString();
            UserInformation.UserEmail = dr["PlayerEmail"].ToString();
            textBox3.Text = dr["PlayerPassword"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {//going to the main page
            ChangePage(new MainPage(), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {//Changeing something need to catch the eh part 
            DatabaseManage dm = new DatabaseManage();
            try
            {
                IsEverythingOkey();
                string[] values = { textBox1.Text, textBox2.Text, textBox3.Text };
                dm.Update(Tables.info, values, UserInformation.UserId);
            }
            catch(Exception exc) when (exc is InformationIsNotFilledException ||
                                       exc is AlreadyUsedUsernameException)
            {
                label4.Text = exc.Message;
            }

        }
        void IsEverythingOkey()
        {
            DatabaseManage dm = new DatabaseManage();
            if(textBox1 == null || textBox2 == null || textBox3 == null)
                throw new InformationIsNotFilledException();

            if (textBox1.Text != UserInformation.UserName)
                if (dm.IsItUsed(textBox1.Text, Records.name))
                    throw new AlreadyUsedUsernameException();

            if (textBox2.Text != UserInformation.UserEmail)
                if (dm.IsItUsed(textBox2.Text, Records.email))
                    throw new AlreadyUsedUsernameException();
        }
    }
}
