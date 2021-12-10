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
            //хотелось вывод в html таблицу но ТГ это не умеет

            /*//грубо запихаем все в таблицу html, без сериализации к такому виду
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
            */

            //грубо запихаем все в таблицу html, без сериализации к такому виду
            if (chat.dictionary != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|РУССКИЙ|АНГЛИЙСКИЙ|ТЕМАТИКА");
                sb.AppendLine("______________________________");
                foreach (Word p in chat.dictionary.Values)
                {
                   // text = text  + p.Russian + " " + p.English + " " + p.Theme  ;
                    sb.AppendLine(" | "+p.Russian + " | " + p.English + " | " + p.Theme + " | ");
                }

                text = sb.ToString();

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
    

