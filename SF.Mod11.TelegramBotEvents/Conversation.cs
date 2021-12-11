using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// класс представляет собой объект чата
    /// </summary>
    public class Conversation
    {
        // добавили коллекцию - ключ слово на русском языке
        public Dictionary<string, Word> Dictionary;

        public bool IsAddingInProcess;

        private Chat telegramChat;

        private List<Message> telegramMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Conversation"/> class.
        /// </summary>
        /// <param name="chat">The chat.</param>
        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            Dictionary = new Dictionary<string, Word>();
        }

        /// <summary>
        /// Сохраняем сообщение в telegramMessages
        /// </summary>
        /// <param name="message">The message.</param>
        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <returns>A long.</returns>
        public long GetId() => telegramChat.Id;

        /// <summary>
        /// метод возврата всех текстовых сообщений
        /// </summary>
        /// <returns>A list of string.</returns>
        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }

            return textMessages;
        }

        /// <summary>
        /// Gets the last message.
        /// </summary>
        /// <returns>A string.</returns>
        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;
    }
}
