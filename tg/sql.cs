using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace tg
{
    public class sql
    {
        private static string CONNECTION_STRING = "Data Source =D:\\2 курс\\gi\\sqlite\\my.db";

        public static List<string> GetUsers()
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var users = new List<string>();
                var command = new SQLiteCommand();
                command.Connection = connection;
                command.CommandText = "select name from user ";
                var reader=command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader.GetString(0));
                }
                return users;
            }
        }

        public static void RegisterUser(string name, string password)
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var command = new SQLiteCommand();
                command.Connection = connection;
                if(!IsExist(name,password))
                { 
                    command.CommandText = $"insert into user (name,password) values ('{name}','{password}')";
                    command.ExecuteNonQuery();
                }


            }
        }
        public static bool IsExist(string name, string password)
        {
            using (var connection = new SQLiteConnection(CONNECTION_STRING))
            {
                connection.Open();
                var command = new SQLiteCommand();
                command.Connection = connection;
                command.CommandText = $"select 1 from user where name like '{name}' and password='{password}'";
                return command.ExecuteScalar() != null;
            }
        }
    }
}
