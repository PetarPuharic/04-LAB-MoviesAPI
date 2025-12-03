using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieControllers : ControllerBase
    {
        public MoviesService moviesService { get; set; }
        public MovieControllers(MoviesService moviesService)
        {
            this.moviesService = moviesService;
        }
        [HttpPost("AddMovie")]
        public IActionResult AddMovie(Data.Movie movie)
        {
            moviesService.AddMovie(movie);
            return Ok();
        }

        [HttpDelete("RemoveMovie/{id}")]
        public IActionResult RemoveMovie(int id)
        {
            moviesService.removeMovie(id);
            return Ok();
        }
        [HttpPut("UpdateMovie/{id}")]
        public IActionResult UpdateMovie(int id, Data.Movie updatedMovie)
        {
            moviesService.updateMovie(id, updatedMovie);
            return Ok();
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var movie = moviesService.getById(id);
            return Ok(movie);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var movies = moviesService.getAll();
            return Ok(movies);
        }
    }
}
