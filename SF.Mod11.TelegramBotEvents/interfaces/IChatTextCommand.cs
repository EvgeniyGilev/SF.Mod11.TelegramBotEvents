using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod11.TelegramBotEvents.Interfaces
{
    /// <summary>
    /// The chat text command.
    /// </summary>
   public interface IChatTextCommand
    {
        /// <summary>
        /// Returns the text.
        /// </summary>
        /// <returns>A string.</returns>
        string ReturnText();
    }
}
