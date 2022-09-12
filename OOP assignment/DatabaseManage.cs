using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace OOP_assignment
{
    public enum tables { score,info}; // The 2 types the tables can be
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
            string insert = MakeStringInsert(where, what);

            //Connecting
            SQLiteConnection conn = new SQLiteConnection("Data Source=customers.db; version=3; New=False: Compress=true");
            conn.Open();

            SQLiteCommand sqlcommand = conn.CreateCommand();
            sqlcommand.CommandText = insert;
            sqlcommand.ExecuteNonQuery();


            //SQLiteDataReader sqlreader;
            //sqlreader = sqlcommand.ExecuteReader();

            //DataTable dt = new DataTable();
            //dt.Load(sqlreader);
        }
    }
}
