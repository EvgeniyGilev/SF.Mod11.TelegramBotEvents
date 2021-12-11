using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod11.TelegramBotEvents.Interfaces
{
    /// <summary>
    /// Интерфейс команда с действием для DoAction 
    /// </summary>
    public interface IChatTextCommandWithAction : IChatTextCommand
    {
        /// <summary>
        /// Выполненяем действие и возвращаем выполнено оно или нет
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <returns>A bool.</returns>
        bool DoAction(Conversation chat);
    }
}
