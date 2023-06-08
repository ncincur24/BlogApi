using BlogApi.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases
{
    public interface IQuerySingle<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest id);
    }
}
