using BlogApi.Application.UseCaseHandling;
using BlogApi.Application.UseCases.Commands;
using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using BlogApi.Implementation;
using Bogus;
using Bogus.DataSets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CategoriesController : ControllerBase
    {
        private IQueryHandler queryHandler;
        private ICommandHandler commandHandler;
        public CategoriesController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this.queryHandler = queryHandler;
            this.commandHandler = commandHandler;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCategoriesQuery query) => Ok(queryHandler.HandleQuery(query, search));

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateLookUpDTO dto, [FromServices] ICreateCategoryCommand command)
        {
            commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CategoriesController>/5
        public void Put(
            [FromBody] LookUpDTO dto,
            [FromServices] ICreateCategoryCommand command)
        {

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
