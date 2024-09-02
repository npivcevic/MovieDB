using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Reflection.Metadata;
using WebApplication1.DataContextLayer;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ActorsRepository(DataContext dataContext)
    {

        public IQueryable<Actor> GetAll()
        {
            return dataContext.Actors;
        }

        public Actor? GetById(Guid id)
        {
            return dataContext.Actors
                .Include(actor => actor.Movies)
                .FirstOrDefault(x => x.Id == id);
        }

        public Actor Create(Actor actor)
        {
            EntityEntry<Actor> newActor = dataContext.Actors.Add(actor);
            dataContext.SaveChanges();

            return GetById(newActor.Entity.Id)!;
        }

        public Actor? Delete(Guid id)
        {
            Actor? actorToDelete = this.GetById(id);

            if (actorToDelete == null)
            {
                return null;
            }

            EntityEntry<Actor> newActor = dataContext.Actors.Remove(actorToDelete);
            dataContext.SaveChanges();

            return newActor.Entity;
        }
        public Actor? Update(Guid id, Actor actor)
        {
            Actor? existingActor = this.GetById(id);

            if (existingActor == null)
            {
                return null;
            }

            //dataContext.ActorMovie.RemoveRange(existingActor.ActorMovies);
            //dataContext.ActorMovie.AddRange(actor.ActorMovies);
            dataContext.Entry(existingActor).CurrentValues.SetValues(actor);

            foreach (ActorMovie actorMovie in actor.ActorMovies)
            {
                var existingActorMovie = existingActor.ActorMovies
                    .FirstOrDefault(p => p.ActorId == actorMovie.ActorId && p.MovieId == actorMovie.MovieId);

                if (existingActorMovie == null)
                {
                    existingActor.ActorMovies.Add(actorMovie);
                }
                else
                {
                    dataContext.Entry(existingActorMovie).CurrentValues.SetValues(actorMovie);
                }
            }

            foreach (ActorMovie actorMovie in existingActor.ActorMovies)
            {
                if (!actor.ActorMovies.Any(p => p.ActorId == actorMovie.ActorId && p.MovieId == actorMovie.MovieId))
                {
                    dataContext.Remove(actorMovie);
                }
            }


            //List<ActorMovie> actorMoviesToRemove = dataContext.ActorMovie.Where(am => am.ActorId == id).ToList();
            //dataContext.ActorMovie.RemoveRange(actorMoviesToRemove);
            //dataContext.ActorMovie.AddRange(actor.ActorMovies);

            //existingActor.FullName = actor.FullName;
            //dataContext.SaveChanges();

            //dataContext.Entry(existingActor).State = EntityState.Detached;
            //dataContext.Entry(actor).State = EntityState.Detached;

            //EntityEntry<Actor> updatedActor = dataContext.Actors.Update(actor);
            dataContext.SaveChanges();

            return GetById(id);
        }
    }
}
