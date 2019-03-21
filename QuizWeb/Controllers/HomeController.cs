using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                QuoteId = quote.Id,
                QuoteText = quote.Text,
            };

            if (mode == "yesNo")
            {
                var randomAuthor = quizService.GetRandomAuthor();
                viewModel.YesNoAuthorId = randomAuthor.Id;
                viewModel.YesNoAuthorName = randomAuthor.Name;
            }
            else if (mode == "multiChoice")
            {
                viewModel.MultiChoiceAuthors = quizService.GetMultiChoiceAuthors(quote.AuthorId).Select(x => new AuthorModel()
                {
                    AuthorId = x.Id,
                    AuthorName = x.Name
                }).ToList();
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string mode, string answer, int quoteId, int authorId)
        {

            if (mode == "yesNo")
            {
                var quote = quoteService.GetQuote(quoteId);

                if (quote.AuthorId == authorId)
                {
                    if (answer == "yes")
                    {
                        return this.Json(new { Result = true, CorrectAnswer = quote.Author.Name });

                    }

                    return this.Json(new { Result = false, CorrectAnswer = quote.Author.Name });
                }
                else
                {
                    if (answer == "no")
                    {
                        return this.Json(new { Result = true, CorrectAnswer = quote.Author.Name });
                    }
                    else
                    {
                        return this.Json(new { Result = false, CorrectAnswer = quote.Author.Name });
                    }
                }
            }
            return null;
        }
    }
}