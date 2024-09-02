namespace WebApplication1.Models
{
    public class TriviaCreateDTO
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
    }
}
