using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.interfaces;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// хранилище команд
    /// </summary>
    public class CommandParser
    {
        private List<IChatCommand> Command;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
        }

        /// <summary>
        /// признак является ли команда текстовой
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsTextCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IChatTextCommand;
        }

        /// <summary>
        /// Проверка что введена команда
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsMessageCommand(string message)
        {
            return Command.Exists(x => x.CheckMessage(message));
        }

        /// <summary>
        /// команда кнопка
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsButtonCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IChatButtonCommand;
        }

    }
}
