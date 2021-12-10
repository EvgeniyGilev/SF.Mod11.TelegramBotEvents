using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.Commands;
using SF.Mod11.TelegramBotEvents.Interfaces;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// хранилище команд
    /// </summary>
    public class CommandParser
    {
        private List<IChatCommand> command;
        private AddingController addingController;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParser"/> class.
        /// </summary>
        public CommandParser()
        {
            command = new List<IChatCommand>();
            addingController = new AddingController();
        }

        /// <summary>
        /// добавление команды в список команд
        /// </summary>
        /// <param name="chatCommand">The chat command.</param>
        public void AddCommand(IChatCommand chatCommand)
        {
            command.Add(chatCommand);
        }

        /// <summary>
        /// признак является ли команда текстовой
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsTextCommand(string message)
        {
            var command = this.command.Find(x => x.CheckMessage(message));

            return command is IChatTextCommand;
        }

        /// <summary>
        /// Проверка что введена команда
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsMessageCommand(string message)
        {
            return command.Exists(x => x.CheckMessage(message));
        }

        /// <summary>
        /// команда кнопка
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsButtonCommand(string message)
        {
            var command = this.command.Find(x => x.CheckMessage(message));

            return command is IChatButtonCommand;
        }

        /// <summary>
        /// Проверка что команда добавления слова
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsAddingCommand(string message)
        {
            var command = this.command.Find(x => x.CheckMessage(message));

            return command is AddWordCommand;
        }

        /// <summary>
        /// Проверка что команда словаря
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public bool IsDictionaryCommand(string message)
        {
            var command = this.command.Find(x => x.CheckMessage(message));

            return command is ShowDictionaryCommand;
        }

        /// <summary>
        /// Получаем введенный пользователем текст команды иди команды и параметра и обрабатываем
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="chat">The chat.</param>
        /// <returns>A string.</returns>
        public string GetMessageText(string message, Conversation chat)
        {
            var command = this.command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if (command is IChatTextCommandWithAction)
            {
                if (!(command as IChatTextCommandWithAction).DoAction(chat))
                {
                    return "Ошибка выполнения команды! Проверьте, что добавили слово для команды";
                }
            }

            return command.ReturnText();
        }
        //// обработка кнопок

        /// <summary>
        /// Adds the callback.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="chat">The chat.</param>
        public void AddCallback(string message, Conversation chat)
        {
            var command = this.command.Find(x => x.CheckMessage(message)) as IChatButtonCommand;
            command.AddCallBack(chat);
        }

        /// <summary>
        /// выводим кнопки
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>An InlineKeyboardMarkup.</returns>
        public InlineKeyboardMarkup GetKeyBoard(string message)
        {
            var command = this.command.Find(x => x.CheckMessage(message)) as IChatButtonCommand;

            return command.ReturnKeyBoard();
        }

        /// <summary>
        /// Информационное сообщение к кнопкам
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A string.</returns>
        public string GetInformationalMeggase(string message)
        {
            var command = this.command.Find(x => x.CheckMessage(message)) as IChatButtonCommand;

            return command.InformationalMessage();
        }

        /// <summary>
        /// Добавляем слово в словарь
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="chat">The chat.</param>
        public void AddWord(string message, Conversation chat)
        {
            var command = this.command.Find(x => x.CheckMessage(message)) as AddWordCommand;

            addingController.AddFirstState(chat);
            command.StartAddWordAction(chat);
        }

        /// <summary>
        /// Следующий шаг добавления слова в словарь
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="chat">The chat.</param>
        public void NextStage(string message, Conversation chat)
        {
            var command = this.command.Find(x => x is AddWordCommand) as AddWordCommand;

            command.DoForStageAsync(addingController.GetStage(chat), chat, message);

            addingController.NextStage(message, chat);
        }
    }
}
