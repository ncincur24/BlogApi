﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Logging
{
    public class UseCaseLogEntry
    {
        public string Actor { get; set; }
        public int ActorId { get; set; }
        public object Data { get; set; }
        public string UseCaseName { get; set; }
    }
}
