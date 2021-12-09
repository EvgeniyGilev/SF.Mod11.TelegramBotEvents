using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.interfaces;

namespace SF.Mod11.TelegramBotEvents.commands
{
    /// <summary>
    /// Команда для добавления слова в словарь
    /// </summary>
    public class AddWordCommand : AbstractCommand, IChatTextCommandWithAction
    {
        public AddWordCommand()
        {
            CommandText = "/addword";
        }

        public bool DoAction(Conversation chat)
        {
            var message = chat.GetLastMessage();

      
                // здесь надо реализовать логику добавления слова
            return false;
        }

        public string ReturnText()
        {
            return "Слово успешно добавлено!";
        }


    }
}
