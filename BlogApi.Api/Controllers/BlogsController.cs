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
        private UseCaseHandler handler;
        public BlogsController(UseCaseHandler handler) => this.handler = handler;
        // GET: api/<BlogsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BlogSearch search, [FromServices] IGetBlogsQuery query)
        {
            try
            {
                return Ok(handler.HandleQuery(query, search));
            }
            catch (Exception)
            {
                return StatusCode(500, "We had a server error");
            }
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleBlogQuery query) => Ok(handler.HandleSingleQuery(query, id));

        // POST api/<BlogsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
