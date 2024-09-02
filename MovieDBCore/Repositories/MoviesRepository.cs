using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.DataContextLayer;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MoviesRepository(DataContext dataContext)
    {

        public IQueryable<Movie> GetAll()
        {
            return dataContext.Set<Movie>();
        }

        public Movie? GetById(Guid id)
        {
            return dataContext.Movies.Include(movie => movie.TriviaList).Include(movie => movie.Actors).FirstOrDefault(x => x.Id == id);
        }

        public Movie Create(Movie movie)
        {
            EntityEntry<Movie> newMovie = dataContext.Movies.Add(movie);
            dataContext.SaveChanges();

            return GetById(newMovie.Entity.Id)!;
        }

        public Movie? Delete(Guid id)
        {
            Movie? movieToDelete = this.GetById(id);

            if (movieToDelete == null)
            {
                return null;
            }

            EntityEntry<Movie> newMovie = dataContext.Movies.Remove(movieToDelete);
            dataContext.SaveChanges();

            return newMovie.Entity;
        }
        public Movie? Update(Guid id, Movie movie)
        {
            Movie? existingMovie = GetById(id);

            if (existingMovie == null)
            {
                return null;
            }

            UpdateMovieTrivia(movie, existingMovie);
            UpdateMovieActors(movie, existingMovie);
            dataContext.Entry(existingMovie).CurrentValues.SetValues(movie);
            dataContext.SaveChanges();

            return GetById(id);
        }

        private void UpdateMovieActors(Movie movie, Movie existingMovie)
        {
            foreach (ActorMovie actorMovie in movie.ActorMovies)
            {
                var existingActorMovies = existingMovie.ActorMovies
                    .FirstOrDefault(p => p.MovieId == actorMovie.MovieId && p.ActorId == actorMovie.ActorId);

                if (existingActorMovies == null)
                {
                    existingMovie.ActorMovies.Add(actorMovie);
                }
                else
                {
                    dataContext.Entry(existingActorMovies).CurrentValues.SetValues(actorMovie);
                }
            }

            foreach (ActorMovie existingActorMovie in existingMovie.ActorMovies)
            {
                if (!movie.ActorMovies.Any(p => p.MovieId == existingActorMovie.MovieId && p.ActorId == existingActorMovie.ActorId))
                {
                    dataContext.Remove(existingActorMovie);
                }
            }
        }

        private void UpdateMovieTrivia(Movie movie, Movie existingMovie)
        {
            foreach (Trivia trivia in movie.TriviaList)
            {
                var existingTrivia = existingMovie.TriviaList
                    .FirstOrDefault(p => p.Id == trivia.Id);

                if (existingTrivia == null)
                {
                    existingMovie.TriviaList.Add(trivia);
                }
                else
                {
                    dataContext.Entry(existingTrivia).CurrentValues.SetValues(trivia);
                }
            }

            foreach (Trivia existingTrivia in existingMovie.TriviaList)
            {
                if (!movie.TriviaList.Any(p => p.Id == existingTrivia.Id))
                {
                    dataContext.Remove(existingTrivia);
                }
            }
        }
    }
}
