using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// The program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main program.
        /// </summary>
        /// <param name="args">The args.</param>
        static void Main(string[] args)
        {
            var bot = new BotWorker();

            bot.Initialize();
            bot.Start();

            Console.WriteLine("Напишите stop для прекращения работы");

            string command;
            do
            {
                command = Console.ReadLine();
            } 
            while (command != "stop");

            bot.Stop();
        }
    }
}
