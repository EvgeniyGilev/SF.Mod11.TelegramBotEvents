using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.interfaces;

namespace SF.Mod11.TelegramBotEvents.commands
{
    /// <summary>
    /// команда с дополнительным текстом после команды
    /// </summary>
    public abstract class ChatTextCommandOption : IChatCommand
    {
        public string CommandText;

        /// <summary>
        /// реализация интерфейса IChatCommand
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public virtual bool CheckMessage(string message)
        {
            return CommandText == message;
        }

        /// <summary>
        /// Для того чтобы отделять команду от слова, добавим также метод, который будет это делать
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A string.</returns>
        public string ClearMessageFromCommand(string message)
        {
            // подстрока с учетом пробела
            return message.Substring(CommandText.Length + 1);
        }

    }
}
