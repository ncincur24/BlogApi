using BlogApi.Application.UseCases.Commands;
using BlogApi.Application.UseCases.DTO;
using BlogApi.DataAccess;
using BlogApi.DataAccess.Extensions;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands
{
    public class CreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        public CreateCategoryCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Create category";

        public string Description => "Create category using Etity Framework";

        public void Execute(LookUpDTO request) => Context.AddEntity(new Category { Name = request.Name });
    }
}
