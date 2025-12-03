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

    }
}
