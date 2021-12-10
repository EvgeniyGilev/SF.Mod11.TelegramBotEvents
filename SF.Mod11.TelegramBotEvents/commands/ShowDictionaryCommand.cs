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

            //грубо запихаем все в таблицу html, без сериализации к такому виду
            text = "<table><colgroup><col span=\"3\" style=\"background: LightCyan\"></colgroup><tr><th>Русский</th><th>Английский</th><th>Тема</th></tr><tr> ";
            if (chat.dictionary != null)
            {
                foreach (Word p in chat.dictionary.Values)
                {
                    text = text + "<td>" + p.Russian + "</td><td>" + p.English + "</td><td>" + p.Theme + "</td>";
                }
                text = text + "</tr></ table ></ table>";


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
    

