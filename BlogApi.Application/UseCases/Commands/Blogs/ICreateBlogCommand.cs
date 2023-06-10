using BlogApi.Application.UseCases.DTO.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.Commands.Blogs
{
    public interface ICreateBlogCommand : ICommand<CreateBlogDTO>
    {
    }
}
