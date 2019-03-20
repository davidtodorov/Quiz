using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.Services.Interfaces;
using QuizWeb.Models;

namespace QuizWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IQuoteService quoteService;
        private readonly IQuizService quizService;

        public HomeController(IAuthorService authorService, IQuoteService quoteService, IQuizService quizService)
        {
            this.authorService = authorService;
            this.quoteService = quoteService;
            this.quizService = quizService;
        }
        public IActionResult Index(string mode = "yesNo")
        {
            var quote = quizService.GetRandomQuote();
            var viewModel = new QuoteAuthorModel()
            {
                Quote = quote.Text,
                ActualAuthor = quote.Author.Name,
            };

            if (mode == "yesNo")
            {
                var randomAuthor = quizService.GetRandomAuthor();
                viewModel.YesNoAuthor = randomAuthor.Name;
            } 
            else if (mode == "multiChoice")
            {
                viewModel.MultiChoiceAuthors = quizService.GetMultiChoiceAuthors(quote.AuthorId);
            }
            
            return View(viewModel);
        }
    }
}