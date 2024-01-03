using Microsoft.EntityFrameworkCore;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;

namespace StudyProject.Infrastructure
{
    public class ApplicationDbContext
    {
        List<Article> Articles { get; set; } = new();

        public List<Article> GetArticles()
        {
            return Articles;
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }

        public void UpdateArticle(Article article)
        {
               var articleToUpdate = Articles.FirstOrDefault(a => a.Id == article.Id);
            articleToUpdate = article;
        }

        public void DeleteArticle(HexId id)
        {
            var articleToDelete = Articles.FirstOrDefault(a => a.Id == id);
            Articles.Remove(articleToDelete);
        }

        public Article GetArticleById(HexId id)
        {
            return Articles.FirstOrDefault(a => a.Id == id);
        }

        public void SaveChanges()
        {
            // do nothing
        }


    }
}
