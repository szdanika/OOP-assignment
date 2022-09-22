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
    public partial class HistoryPage : SuperClass
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//moving back
            ChangePage(new MainPage(), this);
        }

        private void button3_Click(object sender, EventArgs e)
        {// all time list
            dataGridView1.Rows.Clear();
            DataTable dt = ListMaking();
            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["PN"].ToString(), dr["SPD"].ToString(), dr["S"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {// Timed lis
            dataGridView1.Rows.Clear();
            DataTable dt = ListMaking();
            foreach (DataRow dr in dt.Rows)
            {
                if (DateTime.Parse(dr["SPD"].ToString()) >= dateTimePicker1.Value && DateTime.Parse(dr["SPD"].ToString()) <= dateTimePicker2.Value)
                    dataGridView1.Rows.Add(dr["PN"].ToString(), dr["SPD"].ToString(), dr["S"].ToString());
            }
        }
        DataTable ListMaking()
        {
            dataGridView1.Rows.Clear();
            DatabaseManage dm = new DatabaseManage();
            string select = "SELECT PlayerName as PN, SPlayerDate AS SPD, Score as S ";
            string orderBy = " ORDER by SPlayerDate;";
            string where = " WHERE PlayerId = SPlayerId ";
            return dm.Select(select, Tables.info, where, "", orderBy);
        }
    }
}
