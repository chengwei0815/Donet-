using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository

    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            // select top 30 * from movies order by revenue desc
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public IEnumerable<Movie> Get30HighestRatedMovies()
        {
            throw new NotImplementedException();
        }

        public async override Task<Movie> GetById(int id)
        {
            //var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            var movie = await _dbContext.Movies.Include(m => m.GenresOfMovie).ThenInclude(mg => mg.Genre).Include(m => m.Trailers).FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var totalMoviesCountByGenre = await _dbContext.MovieGenres
                    .Where(m => m.GenreId == genreId)
                    .CountAsync();
            if (totalMoviesCountByGenre == 0)
            {
                throw new Exception("No Movies Found for this Genre");
            }
            var movies = await _dbContext.MovieGenres
                    .Where(g => g.GenreId == genreId)
                    .Include(m => m.Movie)
                    .OrderBy(m => m.MovieId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(mg => mg.Movie)
                    .ToListAsync();
            PagedResultSet<Movie> pagedMovies = new PagedResultSet<Movie>(movies, pageNumber, pageSize, totalMoviesCountByGenre);
            return pagedMovies;
        }
    }
}
