using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// перечисление состояний для добавления слова в словарь
    /// </summary>
    public enum AddingState
    {
        Russian,
        English,
        Theme,
        Finish
    }
}
