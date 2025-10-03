using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieServiceMock : IMovieService
    {
        public List<MovieCard> Get30HighestGrossingMovies()
        {
            var movies = new List<MovieCard> {
                new MovieCard { Title = "Inception", Id = 11 },
                new MovieCard { Title = "Interstellar", Id = 22 },
                new MovieCard { Title = "The Dark Knight", Id = 33 },
                new MovieCard { Title = "Deadpool", Id = 44 },
                new MovieCard { Title = "The Avengers", Id = 55 }
            };
            return movies;
        }
    }
}
