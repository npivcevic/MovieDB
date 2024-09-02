using System.Runtime.CompilerServices;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class TriviaMapper
    {
        public static TriviaListDTO ToTriviaListDTO(this Trivia trivia)
        {
            return new TriviaListDTO() {
                Id = trivia.Id,
                Content = trivia.Content
            };
        }

        public static Trivia ToTrivia(this TriviaCreateDTO trivia)
        {
            return new Trivia() {
                Id = trivia.Id,
                Content = trivia.Content
            };
        }
        public static Trivia ToTrivia(this TriviaCreateDTO trivia, Guid movieId)
        {
            return new Trivia()
            {
                Id = trivia.Id,
                Content = trivia.Content,
                MovieId = movieId
            };
        }
    }
}
