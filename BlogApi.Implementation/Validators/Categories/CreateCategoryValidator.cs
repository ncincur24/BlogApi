﻿using BlogApi.Application.UseCases.DTO;
using BlogApi.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators.Categories
{
    public class CreateCategoryValidator : AbstractValidator<CreateLookUpDTO>
    {
        private BlogContext context;
        public CreateCategoryValidator(BlogContext context)
        {
            this.context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty()
                                                          .MinimumLength(3)
                                                          .Must(x => !context.Categories.Any(y => y.Name.ToLower() == x.ToLower() && y.IsActive))
                                                          .WithMessage("Category {PropertyValue} already exist");
        }
    }
}
