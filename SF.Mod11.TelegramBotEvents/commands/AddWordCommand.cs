using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.Interfaces;
using Telegram.Bot;

namespace SF.Mod11.TelegramBotEvents.Commands
{
    /// <summary>
    /// Команда для добавления слова в словарь
    /// </summary>
    public class AddWordCommand : AbstractCommand
    {
        private ITelegramBotClient botClient;

        private Dictionary<long, Word> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddWordCommand"/> class.
        /// </summary>
        /// <param name="botClient">The bot client.</param>
        public AddWordCommand(ITelegramBotClient botClient)
        {
            СommandText = "/addword";
            this.botClient = botClient;

            dictionary = new Dictionary<long, Word>();
        }

        /// <summary>
        /// Начало добавления слова в словарь
        /// </summary>
        /// <param name="chat">The chat.</param>
        public async void StartAddWordAction(Conversation chat)
        {
            dictionary.Add(chat.GetId(), new Word());
            var text = "Введите слово на русском";
            await SendCommandText(text, chat.GetId());
        }

        /// <summary>
        /// Последовательная обработка ввода пользователя и вывод подсказок
        /// </summary>
        /// <param name="addingState">The adding state.</param>
        /// <param name="chat">The chat.</param>
        /// <param name="message">The message.</param>
        public async void DoForStageAsync(AddingState addingState, Conversation chat, string message)
        {
            var word = dictionary[chat.GetId()];
            var text = string.Empty;

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

        /// <summary>
        /// Возвращаем ответ
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="chat">The chat.</param>
        /// <returns>A Task.</returns>
        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }
    }
}
