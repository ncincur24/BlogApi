using BlogApi.Application.UseCaseHandling;
using BlogApi.Application.UseCases.Commands.Blogs;
using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogsController : ControllerBase
    {
        private IQueryHandler queryHandler;
        private ICommandHandler commandHandler;
        private UseCaseHandler wry;
        public BlogsController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this.queryHandler = queryHandler;
            this.commandHandler = commandHandler;
        }

        // GET: api/<BlogsController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BlogSearch search, [FromServices] IGetBlogsQuery query) => Ok(queryHandler.HandleQuery(query, search));

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetSingleBlogQuery query, [FromServices] ISingleQueryHandler singleQuery) => Ok(singleQuery.HandleSingleQuery(query, id));

        // POST api/<BlogsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBlogDTO dto, [FromServices] ICreateBlogCommand command)
        {
            commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<BlogsController>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBlogDTO dto, [FromServices] IUpdateBlogCommand command)
        {
            dto.Id = id;
            commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBlogCommand command)
        {
            commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
