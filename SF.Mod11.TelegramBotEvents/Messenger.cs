using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.Commands;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// «создает» ответы бота в зависимости от поданной команды
    /// </summary>
    public class Messenger
    {
        private CommandParser parser;
        private ITelegramBotClient botClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Messenger"/> class.
        /// </summary>
        /// <param name="botClient">The bot client.</param>
        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            parser = new CommandParser();
            parser.AddCommand(new AddWordCommand(botClient));
            parser.AddCommand(new DeleteWordCommand());
            parser.AddCommand(new OffButtonCommand(botClient));
            parser.AddCommand(new ShowDictionaryCommand(botClient));
        }

        /// <summary>
        /// Makes the answer.
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <returns>A Task.</returns>
        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.GetLastMessage();

            if (chat.IsAddingInProcess)
            {
                parser.NextStage(lastmessage, chat);

                return;
            }

            if (parser.IsMessageCommand(lastmessage))
            {
                await ExecCommand(chat, lastmessage);
            }
            else
            {
                var text = "неверная команда";
                await SendTextMessage(chat, text);
            }
        }

        /// <summary>
        /// обрабатываем команду, определяя какая она.
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="command">The command.</param>
        /// <returns>A Task.</returns>
        public async Task ExecCommand(Conversation chat, string command)
        {
            if (parser.IsTextCommand(command))
            {
                var text = parser.GetMessageText(command, chat);

                await SendTextMessage(chat, text);
            }

            if (parser.IsButtonCommand(command))
            {
                var keys = parser.GetKeyBoard(command);
                var text = parser.GetInformationalMeggase(command);
                parser.AddCallback(command, chat);

                await SendTextWithKeyBoard(chat, text, keys);
            }

            if (parser.IsAddingCommand(command))
            {
                chat.IsAddingInProcess = true;
                parser.AddWord(command, chat);
            }

            if (parser.IsDictionaryCommand(command))
            {
                await SendTextMessageHtml(chat, "Словарь успешно выведен");
            }
        }

        /// <summary>
        /// отправляем ответ в формате html (используем ParseMode.Html можно и другой)
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="text">The text.</param>
        /// <returns>A Task.</returns>
        private async Task SendTextMessageHtml(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
                chatId: chat.GetId(),
                text: text,
                ParseMode.Html);
        }

        /// <summary>
        /// Sends the text message.
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="text">The text.</param>
        /// <returns>A Task.</returns>
        private async Task SendTextMessage(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
                chatId: chat.GetId(),
                text: text);
        }

        /// <summary>
        /// Sends the text with key board.
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="text">The text.</param>
        /// <param name="keyboard">The keyboard.</param>
        /// <returns>A Task.</returns>
        private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        {
            await botClient.SendTextMessageAsync(
                chatId: chat.GetId(), text: text, replyMarkup: keyboard);
        }
    }
}
