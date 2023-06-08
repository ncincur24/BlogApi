﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Logging
{
    public interface IErrorLogger
    {
        void Log(AppError error);
    }
}
