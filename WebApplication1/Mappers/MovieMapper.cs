using System.Runtime.CompilerServices;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class MovieMapper
    {
        public static MovieListDTO ToMovieListDTO(this Movie movie)
        {
            return new MovieListDTO() { Id = movie.Id, Title = movie.Title };
        }

        public static MovieDetailDTO ToMovieDetailDTO(this Movie movie)
        {
            return new MovieDetailDTO() {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                TriviaList = movie.TriviaList.Select(trivia => trivia.ToTriviaListDTO()).ToList(),
                Actors = movie.Actors.Select(actor => actor.ToActorListDTO()).ToList()
            };
        }

        public static Movie ToMovie(this MovieCreateDTO movie)
        {
            return new Movie() {
                Title = movie.Title,
                Description = movie.Description,
                TriviaList = movie.TriviaList.Select(tdto => tdto.ToTrivia()).ToList(),
                ActorMovies = movie.ActorIds.Select(actorId => new ActorMovie() { ActorId = actorId }).ToList()
            };
        }

        public static Movie ToMovie(this MovieCreateDTO movie, Guid id)
        {
            return new Movie()
            {
                Id = id,
                Title = movie.Title,
                Description = movie.Description,
                TriviaList = movie.TriviaList.Select(tdto => tdto.ToTrivia(id)).ToList(),
                ActorMovies = movie.ActorIds.Select(actorId => new ActorMovie() { ActorId = actorId, MovieId = id }).ToList()
            };
        }
    }
}
