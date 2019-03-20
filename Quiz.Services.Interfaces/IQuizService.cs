using System.Collections.Generic;
using Quiz.Models;

namespace Quiz.Services.Interfaces
{
    public interface IQuizService
    {
        Quote GetRandomQuote();

        Author GetRandomAuthor();

        List<Author> GetMultiChoiceAuthors(int correctAuthorId);

    }
}