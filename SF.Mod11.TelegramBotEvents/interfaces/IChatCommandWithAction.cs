﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Mod11.TelegramBotEvents.Interfaces
{
    interface IChatTextCommandWithAction : IChatTextCommand
    {
        bool DoAction(Conversation chat);
    }
}
