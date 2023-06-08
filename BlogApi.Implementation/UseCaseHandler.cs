using BlogApi.Application.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation
{
    public class UseCaseHandler
    {
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                command.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(command.Name + " " + stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> command, TRequest data)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var response = command.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(command.Name + " " + stopwatch.ElapsedMilliseconds);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TResponse HandleSingleQuery<TRequest, TResponse>(IQuerySingle<TRequest, TResponse> command, TRequest id)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var response = command.Execute(id);
                stopwatch.Stop();
                Console.WriteLine(command.Name + " " + stopwatch.ElapsedMilliseconds);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
