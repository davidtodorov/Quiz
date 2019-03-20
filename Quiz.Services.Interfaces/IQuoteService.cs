using System.Collections.Generic;
using Quiz.Models;

namespace Quiz.Services.Interfaces
{
    public interface IQuoteService
    {
        Quote GetQuote(int quoteId);

        IList<Quote> GetAllQuotes();

        void CreateQuote(string text, int authorId);
    }
}