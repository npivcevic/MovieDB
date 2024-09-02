using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController (ActorsService actorsService) : ControllerBase
    {
        // GET: api/<ActorsController>
        [HttpGet]
        public ActionResult<IEnumerable<ActorListDTO>> Get()
        {
            return Ok(actorsService.Get());
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public ActionResult<ActorDetailDTO> Get(Guid id)
        {
            return Ok(actorsService.Get(id));
        }

        // POST api/<ActorsController>
        [HttpPost]
        public ActionResult<ActorDetailDTO> Post([FromBody] ActorCreateDTO value)
        {
            return Ok(actorsService.Create(value));
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public ActionResult<ActorDetailDTO> Put(Guid id, [FromBody] ActorCreateDTO value)
        {
            ActorDetailDTO? actor = actorsService.Update(id, value);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public ActionResult<ActorDetailDTO> Delete(Guid id)
        {
            ActorDetailDTO? actor = actorsService.Delete(id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }
    }
}
