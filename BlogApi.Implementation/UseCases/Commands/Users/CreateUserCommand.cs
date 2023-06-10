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
using BlogApi.Application.Email;

namespace BlogApi.Implementation.UseCases.Commands.Users
{
    public class CreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private CreateUserValidator validator;
        private IEmailSend sender;
        public CreateUserCommand(BlogContext context, CreateUserValidator validator, IEmailSend sender) : base(context)
        {
            this.validator = validator;
            this.sender = sender;
        }

        public int Id => 13;

        public string Name => "Create user";

        public string Description => "Create user using entity framework";

        public void Execute(CreateUserDTO request)
        {
            validator.ValidateAndThrow(request);

            Context.Users.Add(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = 2
            });
            Context.SaveChanges();
            //sender.Send(new MailMessages
            //{

            //    To = request.Email,
            //    From = "asp@ict.edu.rs",
            //    Title = "Successfull registration!",
            //    Body = "Dear " + request.UserName + "\n Please activate your account...."
            //});
        }
    }
}
