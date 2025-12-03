using MoviesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(Movie movie)
        {
            var newMovie = new Movie()
            {
                Id = movie.Id,
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

    }
}