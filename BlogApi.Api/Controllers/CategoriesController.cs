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
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCategoriesQuery query) => Ok(queryHandler.HandleQuery(query, search));

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var faker = new Faker<Category>().CustomInstantiator(f =>
            {
                return new Category
                {
                    Name = f.Commerce.Department()
                };
            });
            var context = new BlogContext();
            var categories = faker.Generate(15);
            categories.ForEach(x => context.Categories.Add(x));
            context.SaveChanges();
            return Ok("Bravo");
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post(
            [FromBody] LookUpDTO dto,
            [FromServices] ICreateCategoryCommand command)=>

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
