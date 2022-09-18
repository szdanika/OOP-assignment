using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace OOP_assignment
{
    public enum Tables { score, info}; // The 2 types the Tables can be
    internal class DatabaseManage
    {
        private string DatabaseName = "Data Source=customers.db; version=3; New=False: Compress=true";
        public string MakeStringInsert(Tables where, string what)
        {
            string insert = "INSERT INTO ";
            switch (where)
            {
                case Tables.score:
                    insert += "PlayerScore (SPlayerDate,Score)";
                    break;
                case Tables.info:
                    insert += "PlayerInfo (PlayerName, PlayerEmail, PlayerPassword)";
                    break;
            }
            insert += " VALUES(" + what + ");";
            return insert;
        }
        public void Insert(Tables where,string what)
        {

            //Connecting
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();

            SQLiteCommand sqlcommand = conn.CreateCommand();

            sqlcommand.CommandText = MakeStringInsert(where, what);

            sqlcommand.ExecuteNonQuery();

            conn.Close();
        }

        public string MakeStringUpdate(Tables where, string[] values)
        {
            string update = "UPDATE ";

            switch (where)
            {
                case Tables.score:
                    update += "PlayerScore";
                    break;
                case Tables.info:
                    update += "PlayerInfo SET PlayerName = '" + values[0] + "', PlayerEmail = '" + values[1] + "', PlayerPassword = '" + values[2] + "'";
                    break;
            }
            update += " Where PlayerId = 1"; // needs to get the id of the user

            return update;
        }
        public void Update()
        {
            //Connecting
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();

            string[] temp = { "FelhNev","FelhEmail","FelhJelsz"};
            sqlcommand.CommandText = MakeStringUpdate(Tables.info, temp);

            sqlcommand.ExecuteNonQuery();

            conn.Close();
        } 
        public int Login(string name, string password)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();
            //sqlcommand.CommandText = MakeStringRequestOne(from, what, where);
            sqlcommand.CommandText = "SELECT PlayerId FROM PlayerInfo WHERE PlayerName = '"+ name+"' AND PlayerPassword = '"+password+"';";

            SQLiteDataReader reader = sqlcommand.ExecuteReader();

            dt.Load(reader);
            DataRow row = dt.Rows[0];
            int back = Convert.ToInt32(row["PlayerId"]);
            conn.Close();
            return back;
        }
        
    }
}
