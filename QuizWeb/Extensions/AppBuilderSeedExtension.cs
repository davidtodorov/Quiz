using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Services;

namespace QuizWeb.Extensions
{
    public static class AppBuilderSeedExtension
    {
        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                //var quoteService = scope.ServiceProvider.GetRequiredService<QuoteService>();
                //var authorService = scope.ServiceProvider.GetRequiredService<AuthorService>();

                //var adminCreated = await authorService.CreateAuthor("avtor");
                //var roleResult = await userManager.AddToRoleAsync(admin, roles[0].Name);

            }
        }
    }
}
