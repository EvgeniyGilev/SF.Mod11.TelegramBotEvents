using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF.Mod11.TelegramBotEvents
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main(string[] args)
        {
            var bot = new BotWorker();

            bot.Inizalize();
            bot.Start();

            Console.WriteLine("Напишите stop для прекращения работы");

            string command;
            do
            {
                command = Console.ReadLine();

            } while (command != "stop");

            bot.Stop();
        }
    }
}
