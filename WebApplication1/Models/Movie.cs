namespace WebApplication1.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public List<Trivia> TriviaList { get; set; } = [];

        public List<Actor> Actors { get; set; } = [];

        public List<ActorMovie> ActorMovies { get; set; } = [];

    }
}
