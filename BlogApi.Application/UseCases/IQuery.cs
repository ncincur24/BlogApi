﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases
{
    public interface IQuery<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest search);   
    }
}
