using BlogApi.Application.UseCaseHandling;
using BlogApi.Application.UseCases;
using BlogApi.Application.UseCases.Commands.Comments;
using BlogApi.Application.UseCases.DTO.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private ICommandHandler commandHandler;
        public CommentsController(ICommandHandler commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        // POST api/<CommentsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDTO dto, [FromServices] ICreateCommentCommand command)
        {
            commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
