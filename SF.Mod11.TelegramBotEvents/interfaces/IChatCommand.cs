using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod11.TelegramBotEvents.interfaces
{
   public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}
