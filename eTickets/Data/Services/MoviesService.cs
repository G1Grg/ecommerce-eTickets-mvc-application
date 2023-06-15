using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _context.Movies
               .Include(c => c.cinema)
               .Include(p => p.producer)
               .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
               .FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
        }


      
    }
}
