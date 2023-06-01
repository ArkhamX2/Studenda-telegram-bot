using model;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;



namespace ConsoleApp1
{
    public class Program
    {
        private static string token { get; set; } = "5926149406:AAG24W75qBUKg-IiGcjPYXRb9np43H7bEBU";
        private static TelegramBotClient client = new TelegramBotClient(token);

        static void Main(string[] args)
        {
            //List<int> chat_id = new List<int>() { 2028880831, 450249503 };
            int chat = 2028880831;
            //mes(chat, "дарова отец");
            //Console.WriteLine(IsExist("sdf", "up"));
            string Name = "df";
            string Password = "gf";
            using (ApplicationContext db = new ApplicationContext())
            {
                var UserList = db.Users.Where(x => x.name == Name).Where(x => x.password == Password).ToList();                
                if (UserList.Count == 0)
                {
                    Console.WriteLine( "ничего нет");
                }
                else
                {
                    foreach (var user in UserList)
                    {
                        Console.WriteLine(user.name);
                    }
                }
            }


            var t = new List<string>() { "негр", "pizza", "upd" };

            Console.ReadLine();

        }
        async static void mes(int chat_id, string message)
        {
            await client.SendTextMessageAsync(chat_id, message);
        }
        public static string RegisterUser(string Name, string Password, string tglt, long chat)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (IsExist(Name, Password))
                {
                    string tgl = "@" + tglt;
                    long tgid = chat;
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
                var UserList = db.Users.Where(x => x.name == Name ).ToList().Where(x=>x.password==Password);

                return UserList != null;
            }
        }
    }
}