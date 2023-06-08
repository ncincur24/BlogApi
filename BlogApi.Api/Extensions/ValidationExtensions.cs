using BlogApi.Application.UseCases.DTO.Errors;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static IEnumerable<string> AllowedExtensions => new List<string>
        {
            "jpg", "jpeg", "mp4", "gif", "png"
        };

        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var errors = result.Errors.Select(x => new ClientErrorDTO
            {
                Error = x.ErrorMessage,
                Property = x.PropertyName
            });

            return new UnprocessableEntityObjectResult(errors);
        }
    }
}
