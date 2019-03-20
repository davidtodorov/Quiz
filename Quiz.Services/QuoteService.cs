using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Interfaces;

namespace Quiz.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly QuizDbContext context;

        public QuoteService(QuizDbContext context)
        {
            this.context = context;
        }

        public Quote GetQuote(int quoteId)
        {
            return context.Quotes.Include(q => q.Author).FirstOrDefault(q => q.Id == quoteId);
        }

        public IList<Quote> GetAllQuotes()
        {
            return context.Quotes.ToList();
        }

        public void CreateQuote(string text, int authorId)
        {
            var quote = new Quote {Text = text, AuthorId = authorId};
            context.Quotes.Add(quote);
        }
    }
}
