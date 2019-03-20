using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Interfaces;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly QuizDbContext context;
        private readonly IQuoteService quoteService;
        private readonly IAuthorService authorService;
        private readonly Random randomGenerator;

        public QuizService(IQuoteService quoteService, IAuthorService authorService)
        {
            this.quoteService = quoteService;
            this.authorService = authorService;
            this.randomGenerator = new Random();
        }
        public void ChooseMode()
        {
            throw new NotImplementedException();
        }

        public Quote GetRandomQuote()
        {
            var quotesCount = quoteService.GetAllQuotes().Count;
            var quoteId = this.randomGenerator.Next(1, quotesCount + 1);
            return quoteService.GetQuote(quoteId);
        }

        public Author GetRandomAuthor()
        {
            var authorsCount = quoteService.GetAllQuotes().Count;
            var authorId = this.randomGenerator.Next(1, authorsCount + 1);
            return authorService.GetAuthor(authorId);
        }

        public List<Author> GetMultiChoiceAuthors(int correctAuthorId)
        {
            var list = new List<Author>();
            var correctAuthor = authorService.GetAuthor(correctAuthorId);
            list.Add(correctAuthor);
            var dbAuthors = authorService.GetAuthors().Where(a => a.Id != correctAuthorId).ToList();
            for (int i = 0; i < 2; i++)
            {
                var randomId = randomGenerator.Next(0, dbAuthors.Count);
                var randomAuthor = dbAuthors.ElementAt(randomId);
                dbAuthors.Remove(randomAuthor);
                list.Add(randomAuthor);
            }
            return list;
        }
    }
}
