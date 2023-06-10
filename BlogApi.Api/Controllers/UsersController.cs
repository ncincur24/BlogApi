using BlogApi.Application.UseCaseHandling;
using BlogApi.Application.UseCases.Commands.Users;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.DTO.Users;
using BlogApi.Application.UseCases.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IQueryHandler queryHandler;
        private ICommandHandler commandHandler;

        public UsersController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this.queryHandler = queryHandler;
            this.commandHandler = commandHandler;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch dto, [FromServices] IGetUsersQuery query) => Ok(queryHandler.HandleQuery(query, dto));

        // POST api/<UsersController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateUserDTO dto, [FromServices] ICreateUserCommand command)
        {
            commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserRoleDTO dto, [FromServices] IUpdateUserRoleCommand command)
        {
            dto.Id = id;
            commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
