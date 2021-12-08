using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents
{
    public class BotMessageLogic
    {

        private Messenger messanger;
        private ITelegramBotClient botClient;

        private Dictionary<long, Conversation> chatList;
        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messanger = new Messenger();
            chatList = new Dictionary<long,
                Conversation>();
            this.botClient = botClient;
        }
        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newchat);
            }

            var chat = chatList[Id];

            chat.AddMessage(e.Message);
            if (chat.GetLastMessage() == "/askme")
            {
                await SendTextWithKeyBoard(chat, "может...", ReturnKeyBoard());
            }
            else
            {
                await SendTextMessage(chat);
            }
            //await SendTextMessage(chat);

        }
        private async Task SendTextMessage(Conversation chat)
        {
            var text = messanger.CreateTextMessage(chat);

            await botClient.SendTextMessageAsync(
                chatId: chat.GetId(), text: text);
        }
        private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        {
            await botClient.SendTextMessageAsync(
                chatId: chat.GetId(), text: text, replyMarkup: keyboard);
        }
        public InlineKeyboardMarkup ReturnKeyBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton
                {
                    Text = "Пойдем спать?",
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
