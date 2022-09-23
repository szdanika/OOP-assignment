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
using PdfManager;

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
            DataTable dt = MakeNewDatatable(ListMaking());
            foreach (DataRow dr in dt.Rows)
            {
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

        private void button5_Click(object sender, EventArgs e)
        {//all time list to pdf
            try
            {
                string directory = GetDirectory();
                DataTable dt = ListMaking();
                MakingPdf makepdf = new MakingPdf();
                string[] pef = { "PN", "SPD", "S" };
                makepdf.MakePdf(dt, directory, "AllTimeScores", "AllTimeScores", pef);
            }
            catch(Exception exc)
            {
                label3.Text = exc.Message;
                label3.Visible = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {//Selected time score pdf
            try
            {
                string directory = GetDirectory();
                DataTable dt = MakeNewDatatable(ListMaking());
                MakingPdf makepdf = new MakingPdf();
                string[] pef = { "PN", "SPD", "S" };
                makepdf.MakePdf(dt, directory, "SelectedTimeScore", "SelectedTimeScore", pef);
            }
            catch(Exception exc)
            {
                label3.Text = exc.Message;
                label3.Visible = true;
            }
        }
        DataTable MakeNewDatatable(DataTable originaldt)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PN");
            dt.Columns.Add("SPD");
            dt.Columns.Add("S");
            foreach (DataRow row in originaldt.Rows)
            {
                if (DateTime.Parse(row["SPD"].ToString()) >= dateTimePicker1.Value && DateTime.Parse(row["SPD"].ToString()) <= dateTimePicker2.Value)
                {
                    DataRow dr = dt.NewRow();
                    dr["PN"] = row["PN"];
                    dr["SPD"] = row["SPD"];
                    dr["S"] = row["S"];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
