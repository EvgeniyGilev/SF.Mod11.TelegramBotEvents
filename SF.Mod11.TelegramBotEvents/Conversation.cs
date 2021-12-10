using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SF.Mod11.TelegramBotEvents
{
    public class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        // добавили коллекцию - ключ слово на русском языке
        public Dictionary<string, Word> dictionary;

        public bool IsAddingInProcess;


        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            dictionary = new Dictionary<string, Word>();
        }
        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }
        public long GetId() => telegramChat.Id;

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
        //должно ли отрабатывать при первом сообщении?
        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;
      
    }
}
