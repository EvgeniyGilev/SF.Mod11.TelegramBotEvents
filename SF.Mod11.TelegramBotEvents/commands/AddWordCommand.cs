using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.interfaces;
using Telegram.Bot;

namespace SF.Mod11.TelegramBotEvents.commands
{
    /// <summary>
    /// Команда для добавления слова в словарь
    /// </summary>
    public class AddWordCommand : AbstractCommand
    {
        private ITelegramBotClient botClient;

        private Dictionary<long, Word> dictionary;
        public AddWordCommand(ITelegramBotClient botClient)
        {
            CommandText = "/addword";
            this.botClient = botClient;

            dictionary = new Dictionary<long, Word>();
        }

        public async void DoAction(Conversation chat)
        {
            //var message = chat.GetLastMessage();
            dictionary.Add(chat.GetId(), new Word());
            var text = "Введите слово на русском";
            await SendCommandText(text, chat.GetId());

            // здесь надо реализовать логику добавления слова

        }

        public string ReturnText()
        {
            return "Слово успешно добавлено!";
        }
        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }


    }
}
