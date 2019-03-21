using System;
using System.Collections.Generic;
using Quiz.Models;

namespace QuizWeb.Models
{
    public class QuoteAuthorModel
    {
        public Quote Quote { get; set; }

        public Author ActualAuthor { get; set; }

        public Author YesNoAuthor { get; set; }

        public List<Author> MultiChoiceAuthors { get; set; }
    }
}
