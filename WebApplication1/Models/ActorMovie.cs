using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ActorMovie
    {
        [Key]
        public Guid MovieId { get; set; }
        [Key]
        public Guid ActorId { get; set; }

        public Actor? Actor { get; set; }
        public Movie? Movie { get; set; }
    }
}
