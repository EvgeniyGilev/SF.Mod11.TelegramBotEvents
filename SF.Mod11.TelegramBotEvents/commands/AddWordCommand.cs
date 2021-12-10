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

        public async void StartAddWordAction(Conversation chat)
        {
            //var message = chat.GetLastMessage();
            dictionary.Add(chat.GetId(), new Word());
            var text = "Введите слово на русском";
            await SendCommandText(text, chat.GetId());

            // здесь надо реализовать логику добавления слова

        }

        public async void DoForStageAsync(AddingState addingState, Conversation chat, string message)
        {
            var word = dictionary[chat.GetId()];
            var text = "";

            switch (addingState)
            {
                case AddingState.Russian:
                    word.Russian = message;

                    text = "Введите английское значение слова";
                    break;

                case AddingState.English:
                    word.English = message;

                    text = "Введите тематику";
                    break;

                case AddingState.Theme:
                    word.Theme = message;

                    text = "Успешно! Слово " + word.English + " добавлено в словарь. ";

                    chat.dictionary.Add(word.Russian, word);

                    dictionary.Remove(chat.GetId());
                    break;
            }


            await SendCommandText(text, chat.GetId());
        }

        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }


    }
}
