using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using BlogApi.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Queries
{
    public class GetLogQuery : EfUseCase, IGetLogQuery
    {
        private LogSearchValidator validator;
        public GetLogQuery(BlogContext context, LogSearchValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 15;

        public string Name => "Get Logs";

        public string Description => "Search logs using entity framework";

        public IEnumerable<LogDTO> Execute(LogSearch search)
        {
            validator.ValidateAndThrow(search);

            var logs = Context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                logs = logs.Where(x => x.UseCaseName.Contains(search.Keyword));
            }
            if(search.DateFrom != null)
            {
                logs = logs.Where(x => x.CreatedAt > search.DateFrom);
            }
            if(search.DateTo != null)
            {
                logs = logs.Where(x => x.CreatedAt < search.DateTo);
            }
            return logs.Select(x => new LogDTO
            {
                Id = x.Id,
                Actor = x.Actor,
                CreatedAt = x.CreatedAt,
                UseCasename = x.UseCaseName,
                UseCaseData = x.UseCaseData
            }).ToList();
        }
    }
}
