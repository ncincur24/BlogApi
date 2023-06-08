using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO.Errors
{
    public class ClientErrorDTO
    {
        public string Property { get; set; }
        public string Error { get; set; }
    }
}
