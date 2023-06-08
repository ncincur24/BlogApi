using BlogApi.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCaseHandling
{
    public interface ICommandHandler
    {
        void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data);
    }
}
