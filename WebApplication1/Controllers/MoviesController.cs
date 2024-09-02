using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController (MoviesService moviesService) : ControllerBase
    {
        // GET: api/<MoviesController>
        [HttpGet]
        public ActionResult<IEnumerable<MovieListDTO>> Get()
        {
            return Ok(moviesService.Get());
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public ActionResult<MovieDetailDTO> Get(Guid id)
        {
            MovieDetailDTO? foundMovie = moviesService.Get(id);

            if (foundMovie == null)
            {
                return NotFound();
            }

            return Ok(foundMovie);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] MovieCreateDTO value)
        {
            return Ok(moviesService.Create(value));
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public ActionResult<MovieDetailDTO> Put(Guid id, [FromBody] MovieCreateDTO value)
        {
            MovieDetailDTO? updatedMovie = moviesService.Update(id, value);

            if (updatedMovie == null)
            {
                return NotFound();
            }

            return Ok(updatedMovie);
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public ActionResult<MovieDetailDTO> Delete(Guid id)
        {
            MovieDetailDTO? deletedMovie = moviesService.Delete(id);

            if (deletedMovie == null)
            {
                return NotFound();
            }

            return Ok(deletedMovie);
        }
    }
}
