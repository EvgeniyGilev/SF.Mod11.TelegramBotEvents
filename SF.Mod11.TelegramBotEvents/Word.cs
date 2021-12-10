using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// Класс слово
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Слово на Английском
        /// </summary>
        public string English { get; set; }

        /// <summary>
        /// Слово на Русском
        /// </summary>
        public string Russian { get; set; }

        /// <summary>
        /// тематика слова
        /// </summary>
        public string Theme { get; set; }
    }
}
