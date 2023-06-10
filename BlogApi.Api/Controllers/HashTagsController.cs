using BlogApi.Application.UseCaseHandling;
using BlogApi.Application.UseCases.Commands;
using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using BlogApi.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HashTagsController : ControllerBase
    {
        private IQueryHandler queryHandler;
        private ICommandHandler commandHandler;
        public HashTagsController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this.queryHandler = queryHandler;
            this.commandHandler = commandHandler;
        }
        // GET: api/<HashTagsController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetHashTagsQuery query) => Ok(queryHandler.HandleQuery(query, search));

        // POST api/<HashTagsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLookUpDTO dto, [FromServices] ICreateHashTagCommand command)
        {
            commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<HashTagsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HashTagsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
