using BlogApi.Application.UseCases.DTO;
using BlogApi.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected bool Exists<Type>(int? id, DbSet<Type> entity) where Type : Entity
        {
            return entity.Any(x => x.Id == id);
        }
    }
}
