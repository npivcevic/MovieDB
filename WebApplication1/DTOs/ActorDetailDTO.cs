using WebApplication1.DTOs;

namespace WebApplication1.Models
{
    public class ActorDetailDTO
    {
        public Guid Id { get; set; }

        public required string FullName { get; set; }

        public List<MovieListDTO> Movies { get; set; } = [];
    }
}
