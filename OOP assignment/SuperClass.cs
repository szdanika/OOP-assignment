using DatabaseManager;
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
        public DatabaseManager.DatabaseManage dm = new DatabaseManager.DatabaseManage();
        protected void ChangePage(Form to, Form from)
        {
            from.Hide();
            to.ShowDialog();
            from.Close();
        }
        protected string GetDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath == "")
                throw new IncorrectInformationException();
            return folderBrowserDialog.SelectedPath;
        }
    }
}
