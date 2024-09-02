namespace WebApplication1.Models
{
    public class Trivia
    {
        public Guid Id { get; set; }

        public required string Content { get; set; }

        public Guid MovieId { get; set; }

        public Movie? Movie { get; set; }
    }
}
