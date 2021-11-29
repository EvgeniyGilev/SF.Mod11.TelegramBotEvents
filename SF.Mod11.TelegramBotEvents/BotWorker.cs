using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SF.Mod11.TelegramBotEvents
{
    public class BotWorker
    {
        private ITelegramBotClient botClient;

        public void Inizalize()
        {
            this.botClient = new TelegramBotClient(BotCredentials.BotToken);
        }

        public void Start()
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        private async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Получено сообщение в чате: {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat, text: "Вы написали:\n" + e.Message.Text);
            }
        }
    }
}
