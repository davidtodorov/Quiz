using System;
using System.Collections.Generic;
using Quiz.Models;

namespace Quiz.Services.Interfaces
{
    public interface IAuthorService
    {
        Author GetAuthor(int id);
        IList<Author> GetAuthors();
        void CreateAuthor(string name);
    }
}
