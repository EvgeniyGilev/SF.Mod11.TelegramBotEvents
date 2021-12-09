using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF.Mod11.TelegramBotEvents
{
    public class Messenger
    {
        private CommandParser parser;
        private ITelegramBotClient botClient;

        //простая обработка команд в switch
        /*
        public string CreateTextMessage(Conversation chat)
        {
            var text = "";

            switch (chat.GetLastMessage())
            {
                case "/saymehi":
                    text = "Привет";
                    break;
                case "/askme":
                    text = "Как дела?";
                    break;
                default:
                    var delimiter = ",";
                    text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
                    break;
            }

            return text;
        }*/

        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.GetLastMessage();

            if (parser.IsMessageCommand(lastmessage))
            {
                await ExecCommand(chat, lastmessage);
            }
            else
            {
                var text = CreateTextMessage();

                await SendText(chat, text);
            }
        }
        public async Task ExecCommand(Conversation chat, string command)
        {
            if (parser.IsTextCommand(command))
            {
                var text = parser.GetMessageText(command, chat);

                await SendText(chat, text);
            }

            if (parser.IsButtonCommand(command))
            {
                var keys = parser.GetKeyBoard(command);
                var text = parser.GetInformationalMeggase(command);
                parser.AddCallback(command, chat);

                await SendTextWithKeyBoard(chat, text, keys);

            }

            if (parser.IsAddingCommand(command))
            {
                chat.IsAddingInProcess = true;
                parser.StartAddingWord(command, chat);
            }
        }


    }
}
