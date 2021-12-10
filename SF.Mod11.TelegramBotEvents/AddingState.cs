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
        /// <summary>
        /// добавляем слово на русском, начальное состояние
        /// </summary>
        Russian,

        /// <summary>
        /// добавляем слово на английском
        /// </summary>
        English,

        /// <summary>
        /// добавляем тематику
        /// </summary>
        Theme,

        /// <summary>
        /// завершение добавления, конечное состояние
        /// </summary>
        Finish
    }
}
