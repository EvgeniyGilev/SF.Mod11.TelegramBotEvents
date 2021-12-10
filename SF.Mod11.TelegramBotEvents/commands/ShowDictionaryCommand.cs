using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.Interfaces;
using Telegram.Bot;

namespace SF.Mod11.TelegramBotEvents.Commands
{
    /// <summary>
    /// Команда отображающая слова в словаре
    /// </summary>
    public class ShowDictionaryCommand : AbstractCommand, IChatTextCommandWithAction
    {

        private ITelegramBotClient botClient;
        private string text;


        /// <summary>
        /// Initializes a new instance of the <see cref="ShowDictionaryCommand"/> class.
        /// </summary>
        /// <param name="botClient">The bot client.</param>
        public ShowDictionaryCommand(ITelegramBotClient botClient)
        {
            СommandText = "/dictionary";
            this.botClient = botClient;
        }


        /// <summary>
        /// Выводим словарь в таблицу
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <returns>A bool.</returns>
        public bool DoAction(Conversation chat)
        {
            if (chat.dictionary != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|РУССКИЙ|АНГЛИЙСКИЙ|ТЕМАТИКА");
                sb.AppendLine("______________________________");
                foreach (Word p in chat.dictionary.Values)
                {
                    // text = text  + p.Russian + " " + p.English + " " + p.Theme  ;
                    sb.AppendLine(" | " + p.Russian + " | " + p.English + " | " + p.Theme + " | ");
                }

                text = sb.ToString();

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the text.
        /// </summary>
        /// <returns>A string.</returns>
        public string ReturnText()
        {
            return text;
        }
    }
}
