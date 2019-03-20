using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Interfaces;

namespace Quiz.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly QuizDbContext context;

        public AuthorService(QuizDbContext context)
        {
            this.context = context;
        }

        public Author GetAuthor(int id)
        {
            return context.Authors.FirstOrDefault(x => x.Id == id);
        }

        public IList<Author> GetAuthors()
        {
            return context.Authors.Include(x => x.Quotes).ToList();
        }

        public void CreateAuthor(string name)
        {
            var author = new Author {Name = name};
            context.Authors.Add(author);
        }
    }
}
