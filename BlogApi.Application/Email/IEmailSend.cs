﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Email
{
    public interface IEmailSend
    {
        void Send(MailMessages message);
    }
}
