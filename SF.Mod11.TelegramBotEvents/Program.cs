using System;
using Telegram.Bot;

namespace SF.Mod11.TelegramBotEvents
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var botClient = new TelegramBotClient(BotCredentials.BotToken);
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine("Привет! Меня зовут {0}.", me.FirstName);


        }
    }
}
