using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents.interfaces
{
    /// <summary>
    /// Интерфейс для кнопок
    /// </summary>
    interface IChatButtonCommand
    {
        InlineKeyboardMarkup ReturnKeyBoard();

        void AddCallBack(Conversation chat);

        string InformationalMessage();

    }

}
