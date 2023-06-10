using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Searches;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators
{
    public class LogSearchValidator : AbstractValidator<LogSearch>
    {
        public LogSearchValidator()
        {
            RuleFor(x => x.DateFrom).NotEmpty().When(x => x.DateFrom.HasValue).Must((x, y) => y <= x.DateTo).WithMessage("Date from can't be grater than dat to").Unless(x => !x.DateFrom.HasValue);
        }
    }
}
