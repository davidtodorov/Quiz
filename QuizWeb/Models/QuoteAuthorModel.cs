using System;
using System.Collections.Generic;
using Quiz.Models;

namespace QuizWeb.Models
{
    public class QuoteAuthorModel
    {
        public string Quote { get; set; }

        public string ActualAuthor { get; set; }

        public string YesNoAuthor { get; set; }

        public List<Author> MultiChoiceAuthors { get; set; }
    }
}
