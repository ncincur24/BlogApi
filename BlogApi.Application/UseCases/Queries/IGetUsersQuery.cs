using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.Queries
{
    public interface IGetUsersQuery : IQuery<UserSearch, IEnumerable<GetUserDTO>>
    {
    }
}
