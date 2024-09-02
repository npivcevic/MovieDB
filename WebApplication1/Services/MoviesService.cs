using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class MoviesService (MoviesRepository moviesRepository)
    {
        public IEnumerable<MovieListDTO> Get()
        {
            return moviesRepository.GetAll().Select(movie => movie.ToMovieListDTO());
        }

        public MovieDetailDTO? Get(Guid id)
        {
            Movie? foundMovie = moviesRepository.GetById(id);

            if (foundMovie == null)
            {
                return null;
            }

            return foundMovie.ToMovieDetailDTO();
        }

        public MovieDetailDTO Create(MovieCreateDTO movie)
        {
            Movie newMovie = movie.ToMovie();

            return moviesRepository.Create(newMovie).ToMovieDetailDTO();
        }

        public MovieDetailDTO? Update(Guid id, MovieCreateDTO movie)
        {
            Movie movieToUpdate = movie.ToMovie(id);

            Movie? updatedMovie = moviesRepository.Update(id, movieToUpdate);

            if (updatedMovie == null)
            {
                return null;
            }

            return updatedMovie.ToMovieDetailDTO();
        }

        public MovieDetailDTO? Delete(Guid id)
        {
            Movie? deletedMovie = moviesRepository.Delete(id);

            if (deletedMovie == null)
            {
                return null;
            }

            return deletedMovie.ToMovieDetailDTO();
        }
    }
}
