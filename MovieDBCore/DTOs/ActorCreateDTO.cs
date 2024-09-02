namespace WebApplication1.Models
{
    public class ActorCreateDTO
    {
        public required string FullName { get; set; }

        public List<Guid> MovieIds { get; set; } = [];
    }
}
