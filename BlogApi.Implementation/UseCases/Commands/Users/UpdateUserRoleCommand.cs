using BlogApi.Application.UseCases.Commands.Users;
using BlogApi.Application.UseCases.DTO.Users;
using BlogApi.DataAccess;
using BlogApi.Implementation.Validators.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Users
{
    public class UpdateUserRoleCommand : EfUseCase, IUpdateUserRoleCommand
    {
        private UpdateUserValidator validator;
        public UpdateUserRoleCommand(BlogContext context, UpdateUserValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 14;

        public string Name => "Update user role";

        public string Description => "Update user role using entity framework";

        public void Execute(UpdateUserRoleDTO request)
        {
            validator.ValidateAndThrow(request);

            var user = Context.Users.Find(request.Id);

            user.RoleId=request.RoleId;
            Context.SaveChanges();
        }
    }
}
