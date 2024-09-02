namespace WebApplication1.Models
{
    public class Actor
    {
        public Guid Id { get; set; }

        public required string FullName { get; set; }

        public List<Movie> Movies { get; set; } = [];

        public List<ActorMovie> ActorMovies { get; set; } = [];
    }
}
