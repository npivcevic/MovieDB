using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class MovieCreateDTO
    {
        public required string Title { get; set; }

        [StringLength(4)]
        public string? Description { get; set; }

        public List<TriviaCreateDTO> TriviaList { get; set; } = [];

        public List<Guid> ActorIds { get; set; } = [];
    }
}
