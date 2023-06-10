using BlogApi.Application.UseCases.DTO;
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
    public class UpdateUserValidator : AbstractValidator<UpdateUserRoleDTO>
    {
        BlogContext context;

        public UpdateUserValidator(BlogContext context)
        {
            this.context = context;

            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty().Must(x => Exists(x, context.Users)).WithMessage("This user doesn't exist");
            RuleFor(x => x.RoleId).NotEmpty().Must(x => Exists(x, context.Role)).WithMessage("This role doesn't exist");
        }
        private bool Exists<T>(int id, DbSet<T> entity) where T : Entity
        {
            return entity.Any(x => x.Id == id);
        }
    }
}
