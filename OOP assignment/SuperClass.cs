using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_assignment
{
    public class SuperClass : Form
    {
        protected void ChangePage(Form to, Form from)
        {
            from.Hide();
            to.ShowDialog();
            from.Close();
        }
    }
}
