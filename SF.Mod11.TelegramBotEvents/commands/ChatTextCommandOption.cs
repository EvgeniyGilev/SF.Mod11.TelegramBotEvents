using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.Interfaces;

namespace SF.Mod11.TelegramBotEvents.Commands
{
    /// <summary>
    /// команда с дополнительным текстом после команды
    /// </summary>
    public abstract class ChatTextCommandOption : AbstractCommand
    {
        /// <summary>
        /// Абстрактный класс команда с параметром
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public override bool CheckMessage(string message)
        {
            return message.StartsWith(СommandText);
        }

        /// <summary>
        /// Для того чтобы отделять команду от слова, добавим также метод, который будет это делать
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A string.</returns>
        public string ClearMessageFromCommand(string message)
        {
            // подстрока с учетом пробела
            return message.Substring(СommandText.Length + 1);
        }
    }
}
