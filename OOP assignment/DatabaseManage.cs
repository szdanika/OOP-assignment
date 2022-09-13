using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace OOP_assignment
{
    public enum tables { score, info}; // The 2 types the tables can be
    internal class DatabaseManage
    {

        public string MakeStringInsert(tables where, string what)
        {
            string insert = "INSERT INTO ";
            switch (where)
            {
                case tables.score:
                    insert += "PlayerScore (SPlayerDate,Score)";
                    break;
                case tables.info:
                    insert += "PlayerInfo (PlayerName, PlayerEmail, PlayerPassword)";
                    break;
            }
            insert += " VALUES(" + what + ");";
            return insert;
        }
        public void Insert(tables where,string what)
        {

            //Connecting
            SQLiteConnection conn = new SQLiteConnection("Data Source=customers.db; version=3; New=False: Compress=true");
            conn.Open();

            SQLiteCommand sqlcommand = conn.CreateCommand();

            sqlcommand.CommandText = MakeStringInsert(where, what);

            sqlcommand.ExecuteNonQuery();

            conn.Close();
        }

        public string MakeStringUpdate(tables where, string[] values)
        {
            string update = "UPDATE ";

            switch (where)
            {
                case tables.score:
                    update += "PlayerScore";
                    break;
                case tables.info:
                    update += "PlayerInfo SET PlayerName = '" + values[0] + "', PlayerEmail = '" + values[1] + "', PlayerPassword = '" + values[2] + "'";
                    break;
            }
            update += " Where PlayerId = 1"; // needs to get the id of the user

            return update;
        }
        public void Update()
        {
            //Connecting
            SQLiteConnection conn = new SQLiteConnection("Data Source=customers.db; version=3; New=False: Compress=true");
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();

            string[] temp = { "FelhNev","FelhEmail","FelhJelsz"};
            sqlcommand.CommandText = MakeStringUpdate(tables.info, temp);

            sqlcommand.ExecuteNonQuery();

            conn.Close();
        } 
    }
}
