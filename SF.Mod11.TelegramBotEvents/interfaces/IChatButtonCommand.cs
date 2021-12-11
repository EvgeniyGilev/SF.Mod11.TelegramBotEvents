using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents.Interfaces
{
    /// <summary>
    /// Интерфейс для кнопок
    /// </summary>
    public interface IChatButtonCommand
    {
        /// <summary>
        /// Returns the key board.
        /// </summary>
        /// <returns>An InlineKeyboardMarkup.</returns>
        InlineKeyboardMarkup ReturnKeyBoard();

        /// <summary>
        /// Adds the call back.
        /// </summary>
        /// <param name="chat">The chat.</param>
        void AddCallBack(Conversation chat);

        /// <summary>
        /// Informational the message.
        /// </summary>
        /// <returns>A string.</returns>
        string InformationalMessage();
    }
}
