using BlogApi.Application;
using BlogApi.Application.UseCases.Commands;
using BlogApi.Application.UseCases.DTO;
using BlogApi.DataAccess;
using BlogApi.DataAccess.Extensions;
using BlogApi.Domain.Entities;
using BlogApi.Implementation.Validators.Categories;
using BlogApi.Implementation.Validators.HashTags;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Categories
{
    public class CreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private CreateCategoryValidator validator;
        public CreateCategoryCommand(BlogContext context, CreateCategoryValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 5;

        public string Name => "Create category";

        public string Description => "Create category using Etity Framework";

        public void Execute(CreateLookUpDTO request)
        {
            validator.ValidateAndThrow(request);

            Context.AddEntity(new Category { Name = request.Name });
            Context.SaveChanges();
        }
    }
}
