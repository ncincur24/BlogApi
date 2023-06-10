using BlogApi.Application.UseCases.DTO.Users;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        private BlogContext context;
        public CreateUserValidator(BlogContext context)
        {
            this.context = context;

            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UserName).NotEmpty().Matches("^(?=.*[a-zA-Z])[a-zA-Z0-9]{4,30}$").WithMessage("Username must have at least one letter and can't have special characters").Must(x => !context.Users.Any(y => x.ToLower() == y.UserName.ToLower())).WithMessage("Username {PropertyName} is already taken");

            RuleFor(x => x.FirstName).NotEmpty().Matches("^[A-Z][a-z]{2,15}$").WithMessage("Please enter name ex. Joe");

            RuleFor(x => x.LastName).NotEmpty().Matches("^[A-Z][a-z]{2,15}(\\s([A-Z][az]{2,15})){0,3}$").WithMessage("Please enter last name ex. James");                                     

            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(x => !context.Users.Any(y => x.ToLower() == y.Email.ToLower())).WithMessage("Email {PropertyName} is already taken");

            RuleFor(x => x.Password).NotEmpty().Matches("^(?=.*[a-zA-Z])(?=.*\\d).{8,}$");
        }
        private bool Exists<T>(int? id, DbSet<T> entity) where T : Entity
        {
            return !entity.Any(x => x.Id == id);
        }
    }
}
