using BlogApi.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCaseHandling
{
    public class SingleQueryhandler : ISingleQueryHandler
    {
        public TResponse HandleSingleQuery<TRequest, TResponse>(IQuerySingle<TRequest, TResponse> command, TRequest id)
        {
            return command.Execute(id);
        }
    }
}
