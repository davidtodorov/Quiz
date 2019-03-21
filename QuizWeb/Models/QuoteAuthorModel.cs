using System;
using System.Collections.Generic;
using Quiz.Models;

namespace QuizWeb.Models
{
    public class QuoteAuthorModel
    {
        public int QuoteId { get; set; }
        public string QuoteText { get; set; }
        public int YesNoAuthorId { get; set; }
        public string YesNoAuthorName { get; set; }
        public List<AuthorModel> MultiChoiceAuthors { get; set; }
    }
}
