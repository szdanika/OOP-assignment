using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Xml.Linq;

namespace OOP_assignment
{
    public enum Tables { score, info}; // The 2 types the Tables can be
    public enum Records { name, email} // records that i use
    internal class DatabaseManage
    {
        private string DatabaseName = "Data Source=customers.db; version=3; New=False: Compress=true";
        public string MakeStringInsert(Tables where, string what)
        {
            string insert = "INSERT INTO ";
            switch (where)
            {
                case Tables.score:
                    insert += "PlayerScore (SPlayerId,SPlayerDate,Score)";
                    break;
                case Tables.info:
                    insert += "PlayerInfo (PlayerName, PlayerEmail, PlayerPassword)";
                    break;
            }
            insert += " VALUES(" + what + ")";
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
            update += " Where PlayerId = " + UserInformation.UserId;

            return update;
        }
        public void Update(Tables where, string[] what)
        {
            //Connecting
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();

            sqlcommand.CommandText = MakeStringUpdate(where, what);

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
            DataRow row;
            try {  row = dt.Rows[0]; } catch(IndexOutOfRangeException ) { throw new Exceptions.IncorrectInformationException(); }
            int back = Convert.ToInt32(row["PlayerId"]);
            conn.Close();
            return back;
        }
        public bool CheckIfNameUsed(string name)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();

            sqlcommand.CommandText = "SELECT count(PlayerName) as Counted From PlayerInfo WHERE PlayerName = '"+name+"';";

            SQLiteDataReader reader = sqlcommand.ExecuteReader();

            dt.Load(reader);
            DataRow row = dt.Rows[0];
            int back = Convert.ToInt32(row["Counted"]);
            conn.Close();
            return back == 1;
        }
        public bool IsItUsed(string what, Records record)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();
            
            sqlcommand.CommandText = "SELECT count(PlayerName) as Counted From PlayerInfo WHERE "+WhatRecordIsIt(record)+" = '" + what + "';";

            SQLiteDataReader reader = sqlcommand.ExecuteReader();

            dt.Load(reader);
            DataRow row;
            try { row = dt.Rows[0]; } catch (IndexOutOfRangeException ) { throw new Exceptions.IncorrectInformationException(); }
            int back = Convert.ToInt32(row["Counted"]);
            conn.Close();
            return back == 1;
        }
        public String WhatRecordIsIt(Records rec)
        {
            switch(rec)
            {
                case Records.email: return "PlayerEmail";
                case Records.name: return "PlayerName";
            }
            return "";
        }
        public DataTable Select(string select, Tables from, string where, string groupBy, string orderBy)
        {
            string sql = select + " FROM PlayerInfo,PlayerScore" + where + groupBy + orderBy;

            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();

            sqlcommand.CommandText = sql;

            SQLiteDataReader reader = sqlcommand.ExecuteReader();

            dt.Load(reader);

            conn.Close();
            return dt;
        }
        public int GettingIdFromName(string name)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            conn.Open();
            SQLiteCommand sqlcommand = conn.CreateCommand();

            sqlcommand.CommandText = "SELECT PlayerId From PlayerInfo WHERE PlayerName = '" + name + "';";

            SQLiteDataReader reader = sqlcommand.ExecuteReader();

            dt.Load(reader);
            DataRow row;
            try { row = dt.Rows[0]; } catch (IndexOutOfRangeException ) { throw new Exceptions.IncorrectInformationException(); }
            int back = Convert.ToInt32(row["PlayerId"]);
            conn.Close();
            return back;
        }
    }
}
