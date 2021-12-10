using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF.Mod11.TelegramBotEvents
{
    /// <summary>
    /// Класс отвечает за логику работы всего бота
    /// </summary>
    public class BotWorker
    {
        private ITelegramBotClient botClient;
        private BotMessageLogic logic;

        /// <summary>
        /// инициализация бота
        /// </summary>
        public void Initialize()
        {
            this.botClient = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(botClient);
        }

        /// <summary>
        /// Старт обработки сообщений
        /// </summary>
        public void Start()
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
        }

        /// <summary>
        /// остановка обработки сообщений
        /// </summary>
        public void Stop()
        {
            botClient.StopReceiving();
        }

        /// <summary>
        /// обработчик сообщений
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
            {
                await logic.Response(e);
            }
        }
    }
}
