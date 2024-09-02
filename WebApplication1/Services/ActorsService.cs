using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ActorsService (ActorsRepository actorsRepository, MoviesRepository moviesRepository)
    {
        public IEnumerable<ActorListDTO> Get()
        {
            return actorsRepository.GetAll().Select(actor => actor.ToActorListDTO());
        }

        public ActorDetailDTO? Get(Guid id)
        {
            return actorsRepository.GetById(id)?.ToActorDetailDTO();
        }

        public ActorDetailDTO Create(ActorCreateDTO actor)
        {
            Actor newActor = actor.ToActor();

            return actorsRepository.Create(newActor).ToActorDetailDTO();
        }

        public ActorDetailDTO? Update(Guid id, ActorCreateDTO actor)
        {
            Actor newActor = actor.ToUpdatedActor(id);

            return actorsRepository.Update(id, newActor)?.ToActorDetailDTO();
        }

        public ActorDetailDTO? Delete(Guid id)
        {
            return actorsRepository.Delete(id)?.ToActorDetailDTO();
        }
    }
}
