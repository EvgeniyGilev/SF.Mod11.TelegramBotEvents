using SF.Mod11.TelegramBotEvents.Interfaces;

namespace SF.Mod11.TelegramBotEvents.Commands
{
    /// <summary>
    /// Абстрактный класс команд
    /// </summary>
    public abstract class AbstractCommand : IChatCommand
    {
        public string СommandText;

        /// <summary>
        /// Проверка сообщения.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A bool.</returns>
        public virtual bool CheckMessage(string message)
        {
            return СommandText == message;
        }
    }
}
