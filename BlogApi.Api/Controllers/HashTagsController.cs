using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using BlogApi.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashTagsController : ControllerBase
    {
        private UseCaseHandler handler;
        public HashTagsController(UseCaseHandler handler) => this.handler = handler;
        // GET: api/<HashTagsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetHashTagsQuery query)
        {
            try 
            {
                return Ok(handler.HandleQuery(query, search));
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        // GET api/<HashTagsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HashTagsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
