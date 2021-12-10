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
    /// <summary>
    /// Класс отвечающий за основную логику сообщений
    /// </summary>
    public class BotMessageLogic
    {
        private Messenger messanger;
        private ITelegramBotClient botClient;

        private Dictionary<long, Conversation> chatList;

        /// <summary>
        /// Initializes a new instance of the <see cref="BotMessageLogic"/> class.
        /// </summary>
        /// <param name="botClient">The bot client.</param>
        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messanger = new Messenger(botClient);
            chatList = new Dictionary<long, Conversation>();
            this.botClient = botClient;
        }

        /// <summary>
        /// базовый ответ
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>A Task.</returns>
        public async Task Response(MessageEventArgs e)
        {
            var id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(id))
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(id, newchat);
            }

            var chat = chatList[id];

            chat.AddMessage(e.Message);

            await SendMessage(chat);
        }

        /// <summary>
        /// Базовый запрос
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <returns>A Task.</returns>
        private async Task SendMessage(Conversation chat)
        {
            await messanger.MakeAnswer(chat);
        }
    }
}
