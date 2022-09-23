
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
    public partial class MainPage : SuperClass
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePage(new ProfilPage(), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserInformation.UserId = 0;
            ChangePage(new LogInPage(), this);
        }

        private void button3_Click(object sender, EventArgs e)
        {//giving points to the player
            try
            {
                PointsAddingCheck();
                PointsAdding();
            }
            catch(Exception exc) when (exc is IncorrectInformationException ||
                                       exc is InformationIsNotFilledException)
            {
                label1.Text = exc.Message;
                label1.Visible = true;
            }
        }
        void PointsAdding()
        {
            DatabaseManage dm = new DatabaseManage();
            string sql = "'"+dm.GettingIdFromName(textBox1.Text) + "','" + DateTime.Now + "','" + numericUpDown1.Value+ "'"; //DateTime.Now.ToString("yyyy.MM.dd")
            dm.Insert(Tables.score, sql);
        }
        void PointsAddingCheck()
        {
            DatabaseManage dm = new DatabaseManage();
            if (textBox1.Text != "Name")
                if (!dm.IsItUsed(textBox1.Text, Records.name))
                    throw new IncorrectInformationException();
            if(numericUpDown1.Value == 0) throw new InformationIsNotFilledException();
        }

        private void button4_Click(object sender, EventArgs e)
        {//refreshing the ranking table
            dataGridView1.Rows.Clear();
            DataTable dt = GetTheDataTable();
            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["PN"].ToString(), dr["PE"].ToString(), dr["S"].ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {//moving to history page
            ChangePage(new HistoryPage(), this);
        }

        private void button5_Click(object sender, EventArgs e)
        {//puting the list in a pdf
            try
            {
                DataTable dt = GetTheDataTable();
                string directory = GetDirectory();
                MakingPdf makepdf = new MakingPdf();
                string[] pef = { "PN", "PE", "S" };
                makepdf.MakePdf(dt, directory, "RankingList", "Ranking List", pef);
            }
            catch(Exception)
            { }
        }
        DataTable GetTheDataTable()
        {
            DatabaseManage dm = new DatabaseManage();
            string select = "SELECT PlayerName as PN, PlayerEmail AS PE, sum(Score) as S ";
            string orderBy = "ORDER BY Score", groupBy = " GROUP BY PlayerId ", where = " WHERE PlayerId = SPlayerId ";
            return dm.Select(select, Tables.info, where, groupBy, orderBy);
        }
    }
}
