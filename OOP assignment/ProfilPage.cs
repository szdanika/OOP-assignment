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
    public partial class ProfilPage : SuperClass 
    {
        public int PId { get; set; }
        public ProfilPage()
        {
            DatabaseManage dm = new DatabaseManage();
            InitializeComponent();
           // textBox1.Text = dm.RequestOneThing(Tables.info, "asd", "asd");
        }

        private void button1_Click(object sender, EventArgs e)
        {//going to the main page
            ChangePage(new MainPage(), this);
        }
    }
}
