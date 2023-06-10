using BlogApi.Application.UseCaseHandling;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private IQueryHandler queryHandler;

        public LogController(IQueryHandler queryHandler)
        {
            this.queryHandler = queryHandler;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearch search, [FromServices] IGetLogQuery query) => Ok(queryHandler.HandleQuery(query, search));
    }
}
