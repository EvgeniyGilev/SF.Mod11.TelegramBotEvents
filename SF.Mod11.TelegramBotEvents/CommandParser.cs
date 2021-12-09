using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.commands;
using SF.Mod11.TelegramBotEvents.interfaces;
using Telegram.Bot.Types.ReplyMarkups;

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
        /// добавление команды в список команд
        /// </summary>
        /// <param name="chatCommand">The chat command.</param>
        public void AddCommand(IChatCommand chatCommand)
        {
            Command.Add(chatCommand);
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

        /// <summary>
        /// Проверка что команда добавления слова
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsAddingCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is AddWordCommand;
        }

        public string GetMessageText(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if (command is IChatTextCommandWithAction)
            {
                if (!(command as IChatTextCommandWithAction).DoAction(chat))
                {
                    return "Ошибка выполнения команды!";
                };
            }

            return command.ReturnText();
        }
        //обработка кнопок
        public void AddCallback(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatButtonCommand;
            command.AddCallBack(chat);
        }
        public InlineKeyboardMarkup GetKeyBoard(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatButtonCommand;

            return command.ReturnKeyBoard();
        }
        public string GetInformationalMeggase(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatButtonCommand;

            return command.InformationalMessage();
        }

    }
}
