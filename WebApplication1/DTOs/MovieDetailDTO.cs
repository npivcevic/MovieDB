namespace WebApplication1.Models
{
    public class MovieDetailDTO
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public List<TriviaListDTO> TriviaList { get; set; } = [];

        public List<ActorListDTO> Actors { get; set; } = [];

    }
}
