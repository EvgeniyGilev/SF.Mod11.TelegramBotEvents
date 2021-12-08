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
        private BotMessageLogic logic;

        public void Inizalize()
        {
            this.botClient = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(botClient);
        }

        public void Start()
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.OnCallbackQuery += Bot_Callback;
            botClient.StartReceiving();
        }

        private async void Bot_Callback(object sender, CallbackQueryEventArgs e)
        {
            var text = "";

            switch (e.CallbackQuery.Data)
            {
                case "isSleep":
                    text = @"Пойдем, пойдем, я уже засыпаю..ZZZ-ZZ-ZZ-zzz-zz-z";
                    break;
                case "isWork":
                    text = @"Давай поработаем!";
                    break;
                default:
                    break;
            }

            await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, text);
            await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        private async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            // if (e.Message.Text != null)
            // {
            //     Console.WriteLine($"Получено сообщение в чате: {e.Message.Chat.Id}.");
            //
            //     await botClient.SendTextMessageAsync(
            //         chatId: e.Message.Chat, text: "Вы написали:\n" + e.Message.Text);
            // }
            if (e.Message != null)
            {
                await logic.Response(e);
            }
        }
    }
}
