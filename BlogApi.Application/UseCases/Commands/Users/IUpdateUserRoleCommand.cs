using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.Commands.Users
{
    public interface IUpdateUserRoleCommand : ICommand<UpdateUserRoleDTO>
    {
    }
}
