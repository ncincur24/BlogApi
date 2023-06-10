using BlogApi.Application;
using BlogApi.Application.UseCases.Commands;
using BlogApi.Application.UseCases.DTO;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using BlogApi.Implementation.Validators.Categories;
using BlogApi.Implementation.Validators.HashTags;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.HashTags
{
    public class CreateHashTagCommand : EfUseCase, ICreateHashTagCommand
    {
        private CreateHashTagValidator validator;

        public CreateHashTagCommand(BlogContext context, CreateHashTagValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 6;

        public string Name => "Create Hash Tag";

        public string Description => "Create hash tag using entity framework";

        public void Execute(CreateLookUpDTO request)
        {
            validator.ValidateAndThrow(request);

            Context.HashTags.Add(new HashTag { Name = "#" + request.Name });
            Context.SaveChanges();
        }
    }
}
