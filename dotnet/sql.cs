using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using model;
using Telegram.Bot.Types;

namespace tg
{
    public class sql
    {
       

        public static List<string> GetUsers()
        {
            using(ApplicationContext db=new ApplicationContext())
            {
                var UsersText = new List<string>();
                var UserList = db.Users;
                foreach(var user in UserList)
                {
                    UsersText.Add(user.tglink+" "+user.name);
                    
                }
                return UsersText;
            }
        }

        public static string RegisterUser(string Name, string Password,Message msg)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!IsExist(Name, Password))
                {
                    string tgl = "@" + msg.From?.Username;
                    long tgid = msg.Chat.Id;
                    var s = new ChatUser { name = Name, password = Password, chat_id = tgid, tglink = tgl };
                    db.Users.Add(s);
                    db.SaveChanges();
                    return $"Вы успешно зарегистрировались как {Name}";
                }
                return "есть уже такой пользователь";
                
            }
        }
        public static bool IsExist(string Name, string Password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {               
                var UserList = db.Users.Where(x => x.name == Name).Where(x => x.password == Password).ToList();
                
                return UserList.Count !=0;
            }
        }
    }
}
