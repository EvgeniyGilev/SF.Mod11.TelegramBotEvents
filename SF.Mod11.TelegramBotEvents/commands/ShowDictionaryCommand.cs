using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.interfaces;
using Telegram.Bot;

namespace SF.Mod11.TelegramBotEvents.commands
{
    /// <summary>
    /// Команда отображающая слова в словаре
    /// </summary>
    public class ShowDictionaryCommand : AbstractCommand, IChatTextCommandWithAction
    {

        private ITelegramBotClient botClient;
        private string text;


        public ShowDictionaryCommand(ITelegramBotClient botClient)
        {
            CommandText = "/dictionary";
            this.botClient = botClient;
        }


        public bool DoAction(Conversation chat)
        {

            //<table>
            text = "--- СЛОВАРЬ: ---/r/n";
            if (chat.dictionary != null)
            {
                foreach (Word p in chat.dictionary.Values)
                {
                    text = text + p.Russian + " " + p.English + "" + p.Theme + "/r/n";
                }

                return true;
            }
            else 
            return false;
        }

        public string ReturnText()
        {
            return text;
        }


    }
}
    

