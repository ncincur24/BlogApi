using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.UseCases.DTO
{
    public class LogDTO : BaseDTO
    {
        public string Actor { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UseCasename { get; set; }
        public string UseCaseData{ get; set; }
    }
}
