using Microsoft.EntityFrameworkCore;
using StudyProject.Application.Common.Builders;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;

namespace StudyProject.Infrastructure
{
    public class ApplicationDbContext
    {
        public List<Article> Articles = new() { new ArticleBuilder().WithTitle("Foo").WithContent("Bar").Build(), };


        public List<Article> GetArticles()
        {
            return Articles;
        }

        public Task<Article> GetArticleByIdAsync(HexId id)
        {
            return Task.FromResult(Articles.FirstOrDefault(x => x.Id == id));
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task AddArticleAsync(Article article)
        {
            Articles.Add(article);
            return Task.CompletedTask;
        }

        public Task UpdateArticleAsync(Article article)
        {

            var articleToUpdate = Articles.FirstOrDefault(a => a.Id == article.Id);
            articleToUpdate = article;
            return Task.CompletedTask;

        }

        public Task DeleteArticleAsync(HexId id)
        {
            Articles.Remove(Articles.FirstOrDefault(a => a.Id == id));
            return Task.CompletedTask;
        }
    }
}
