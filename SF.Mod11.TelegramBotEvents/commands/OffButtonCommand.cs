using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.interfaces;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents.commands
{
    public class OffButtonCommand : AbstractCommand, IChatButtonCommand
    {
        ITelegramBotClient botClient;

        public OffButtonCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            CommandText = "/askme";
        }

        public void AddCallBack(Conversation chat)
        {
            botClient.OnCallbackQuery += Bot_Callback;
        }

        public string InformationalMessage()
        {
            return "а может... ";
        }

        private async void Bot_Callback(object sender, CallbackQueryEventArgs e)
        {
            var text = "";

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
    }
}
