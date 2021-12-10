using System.Collections.Generic;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// Обработчик состоянии добавления слова в словарь
    /// </summary>
    public class AddingController
    {
        private Dictionary<long, AddingState> chatAdding;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddingController"/> class.
        /// </summary>
        public AddingController()
        {
            chatAdding = new Dictionary<long, AddingState>();
        }

        /// <summary>
        /// начальное состояние добавления слова в словарь
        /// </summary>
        /// <param name="chat">The chat.</param>
        public void AddFirstState(Conversation chat)
        {
            chatAdding.Add(chat.GetId(), AddingState.Russian);
        }

        /// <summary>
        /// Переходим к следующему шагу добавления 
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="chat">The chat.</param>
        public void NextStage(string message, Conversation chat)
        {
            var currentstate = chatAdding[chat.GetId()];
            chatAdding[chat.GetId()] = currentstate + 1;

            if (chatAdding[chat.GetId()] == AddingState.Finish)
            {
                chat.IsAddingInProcess = false;
                chatAdding.Remove(chat.GetId());
            }
        }

        /// <summary>
        /// получаем текущее состояние
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <returns>An AddingState.</returns>
        public AddingState GetStage(Conversation chat)
        {
            return chatAdding[chat.GetId()];
        }
    }
}
