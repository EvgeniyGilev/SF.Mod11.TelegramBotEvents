using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents.Commands
{
    /// <summary>
    /// Команда пример с кнопками
    /// </summary>
    public class OffButtonCommand : AbstractCommand, IChatButtonCommand
    {
        private ITelegramBotClient botClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OffButtonCommand"/> class.
        /// </summary>
        /// <param name="botClient">The bot client.</param>
        public OffButtonCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            СommandText = "/askme";
        }

        /// <summary>
        /// Подписываемся на событие
        /// </summary>
        /// <param name="chat">The chat.</param>
        public void AddCallBack(Conversation chat)
        {
            botClient.OnCallbackQuery += Bot_Callback;
        }

        /// <summary>
        /// Informationals the message.
        /// </summary>
        /// <returns>A string.</returns>
        public string InformationalMessage()
        {
            return "а может... ";
        }

        /// <summary>
        /// Returns the key board.
        /// </summary>
        /// <returns>An InlineKeyboardMarkup.</returns>
        public InlineKeyboardMarkup ReturnKeyBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton
                {
                    Text = "Пора спать?",
                    CallbackData = "isSleep"
                },

                new InlineKeyboardButton
                {
                    Text = "Еще поработаем?",
                    CallbackData = "isWork"
                }
            };

            var keyboard = new InlineKeyboardMarkup(buttonList);

            return keyboard;
        }

        /// <summary>
        /// Ответ на нажатие кнопки пользователя
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void Bot_Callback(object sender, CallbackQueryEventArgs e)
        {
            var text = string.Empty;

            switch (e.CallbackQuery.Data)
            {
                case "isSleep":
                    text = @"Пойдем, пойдем, я уже засыпаю..ZZZ-ZZ-ZZ-zzz-zz-z";
                    break;
                case "isWork":
                    text = @"Давай поработаем!";
                    break;
                default:
                    break;
            }

            await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, text);
            await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }
    }
}
