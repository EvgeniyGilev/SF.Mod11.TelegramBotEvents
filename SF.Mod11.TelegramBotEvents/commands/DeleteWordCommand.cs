using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.Interfaces;

namespace SF.Mod11.TelegramBotEvents.Commands
{
    /// <summary>
    /// Команда удаления слова из словаря
    /// </summary>
    public class DeleteWordCommand : ChatTextCommandOption, IChatTextCommandWithAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWordCommand"/> class.
        /// </summary>
        public DeleteWordCommand()
        {
            СommandText = "/deleteword";
        }

        /// <summary>
        /// Выполняем действие и возвращаем успех если все удалилось и не успех если нет
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <returns>A bool.</returns>
        public bool DoAction(Conversation chat)
        {
            try
            {
                var message = chat.GetLastMessage();
                var text = ClearMessageFromCommand(message);

                if (chat.dictionary?.ContainsKey(text) == true)
                {
                    chat.dictionary.Remove(text);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// возвращаем ответ, если все ок
        /// </summary>
        /// <returns>A string.</returns>
        public string ReturnText()
        {
            return "Слово успешно удалено!";
        }
    }
}
