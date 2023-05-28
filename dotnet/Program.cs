using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


namespace tg
{
    public class Program
    {
        private static string token { get; set; } = "5926149406:AAG24W75qBUKg-IiGcjPYXRb9np43H7bEBU";
        private static TelegramBotClient client=null!;
        private static string[] s = { "Давай пройдем!", "А кто еще кроме меня?" };
        private static string[] stre = { "чем занят", "кто ты", "зачем" };
        private static Message? chat=null!;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving(UpdateMessage, Errors);

            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

        }

        async private static Task Errors(ITelegramBotClient arg1, Exception ex, CancellationToken arg3)
        {

            await client.SendTextMessageAsync(chat.Chat.Id, ex.Message, replyMarkup: GetButtons(s));

        }

        async private static Task UpdateMessage(ITelegramBotClient bot, Update upd, CancellationToken arg3)
        {
            Message? msg = null!;
            msg = upd.Message;
            chat = msg;
            Console.WriteLine(msg.Text);

            if (msg.Text == "/start")
            {

                await client.SendTextMessageAsync(msg.Chat.Id, "Давай пройдем регистрацию", replyMarkup: GetButtons(s));
            }
            if (msg.Text == "Давай пройдем!")
            {
                await client.SendTextMessageAsync(msg.Chat.Id, "напиши имя (Пример: Имя:Чубирик Пароль:qwer )");
            }
            if (msg.Text.Contains("Имя:") && msg.Text.Contains("Пароль:"))
            {
                var info = msg.Text.Split(' ');
                int found = 0;
                for (int i = 0; i < info.Length; i++)
                {
                    found = info[i].IndexOf(':');
                    info[i] = info[i].Substring(found + 1);
                }
                await client.SendTextMessageAsync(msg.Chat.Id, info[0] + " " + info[1]);
                sql.RegisterUser(info[0], info[1]);

            }
            if (msg.Text == "А кто еще кроме меня?")
            {
                string users = string.Empty;
                if (sql.GetUsers() == null)
                {
                    await client.SendTextMessageAsync(msg.Chat.Id, $"никто", replyMarkup: GetButtons(s));

                }
                else
                {
                    foreach (var user in sql.GetUsers())
                    {
                        users += user + Environment.NewLine;
                    }
                    await client.SendTextMessageAsync(msg.Chat.Id, $"Пользователи:\n{users}", replyMarkup: GetButtons(s));
                }


            }




        }
        #region Создание динамических кнопок
        /// <summary>
        /// функция для динамического создания кнпок 
        /// нужна для создания меню кнопок 
        /// </summary>
        /// <param name="ButtonText">массив названия кнопок</param>
        /// <returns>массив кнопок</returns>
        private static IReplyMarkup GetButtons(string[] ButtonText)
        {
            var keyboard = new List<List<KeyboardButton>>();

            for (int i = 0; i < ButtonText.Length; i++)
            {
                keyboard.Add(new List<KeyboardButton>() { new KeyboardButton(ButtonText[i]) });
            }
            return new ReplyKeyboardMarkup(keyboard);
        }
        #endregion
    }
}

