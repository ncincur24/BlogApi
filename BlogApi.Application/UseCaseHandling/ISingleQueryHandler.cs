using BlogApi.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCaseHandling
{
    public interface ISingleQueryHandler
    {
        TResponse HandleSingleQuery<TRequest, TResponse>(IQuerySingle<TRequest, TResponse> command, TRequest id);
    }
}
