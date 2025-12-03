using MoviesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

        public void removeMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public void updateMovie(int id, Movie updatedMovie)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                movie.Name = updatedMovie.Name;
                movie.Year = updatedMovie.Year;
                movie.Genre = updatedMovie.Genre;
                _context.SaveChanges();
            }
        }

        public Movie getById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> getAll()
        {
            return _context.Movies.ToList();
        }
    }
}