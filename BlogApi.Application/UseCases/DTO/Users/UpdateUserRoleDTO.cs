using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO.Users
{
    public class UpdateUserRoleDTO : BaseDTO
    {
        public int RoleId { get; set; }
    }
}
