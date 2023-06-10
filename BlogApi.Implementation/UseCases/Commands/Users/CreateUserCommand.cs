using BlogApi.Application.UseCases.Commands.Users;
using BlogApi.Application.UseCases.DTO.Users;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using BlogApi.Implementation.Validators.Users;
using FluentValidation;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Users
{
    public class CreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private CreateUserValidator validator;
        public CreateUserCommand(BlogContext context, CreateUserValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 13;

        public string Name => "Create user";

        public string Description => "Create user using entity framework";

        public void Execute(CreateUserDTO request)
        {
            validator.ValidateAndThrow(request);

            //var hash = BCrypt.HashPassword(request.Password);
            Context.Users.Add(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                RoleId = 2
            });
            Context.SaveChanges();
        }
    }
}
