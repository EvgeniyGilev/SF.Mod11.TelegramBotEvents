using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod11.TelegramBotEvents.Interfaces
{
    /// <summary>
    /// интерфейс для команд 
    /// </summary>
    public interface IChatCommand
    {
        /// <summary>
        /// Проверка введенной команды
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        bool CheckMessage(string message);
    }
}
