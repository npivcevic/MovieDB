using System.Runtime.CompilerServices;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class ActorMapper
    {
        public static ActorListDTO ToActorListDTO(this Actor actor)
        {
            return new ActorListDTO() {
                Id = actor.Id,
                FullName = actor.FullName
            };
        }
        public static ActorDetailDTO ToActorDetailDTO(this Actor actor)
        {
            return new ActorDetailDTO()
            {
                Id = actor.Id,
                FullName = actor.FullName,
                Movies = actor.Movies.Select(movie => movie.ToMovieListDTO()).ToList()
            };
        }

        public static Actor ToActor(this ActorCreateDTO actor)
        {
            return new Actor() {
                FullName = actor.FullName,
                ActorMovies = actor.MovieIds.Select(movieId => new ActorMovie { MovieId = movieId }).ToList()
            };
        }

        public static Actor ToUpdatedActor(this ActorCreateDTO actor, Guid id)
        {
            return new Actor()
            {
                Id = id,
                FullName = actor.FullName,
                ActorMovies = actor.MovieIds.Select(movieId => new ActorMovie { ActorId = id, MovieId = movieId }).ToList()
            };
        }
    }
}
