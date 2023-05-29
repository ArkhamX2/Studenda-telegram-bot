using model;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1
{
    internal class Program
    {
        private static TelegramBotClient client=null!;
        private static string token { get; set; } = "5926149406:AAG24W75qBUKg-IiGcjPYXRb9np43H7bEBU";

         static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            List<int> chat_id = new List<int>() { 2028880831, 450249503 };
            foreach(int s in chat_id)
            {
                mes(s);
            }
            Console.ReadLine();

        }
        async static void mes(int chat_id)
        {
            await client.SendTextMessageAsync(chat_id, "на экзамене халявы не будет");

        }
    }
}