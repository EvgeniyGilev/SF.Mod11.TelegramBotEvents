﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Mod11.TelegramBotEvents.interfaces;

namespace SF.Mod11.TelegramBotEvents.commands
{
    public class DeleteWordCommand : ChatTextCommandOption, IChatTextCommandWithAction
    {
        public DeleteWordCommand()
        {
            CommandText = "/deleteword";
        }

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
            catch (Exception e)
            {
                return false;
            }

            return false;
        }

        public string ReturnText()
        {
            return "Слово успешно удалено!";
        }


    }
}
