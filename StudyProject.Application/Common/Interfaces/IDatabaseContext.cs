using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Application.Common.Interfaces
{
    public interface IDatabaseContext
    {
        Task<string> AddArticleAsync(Article article);
        Task<Article> GetArticleAsync(string id);
        Task<bool> UpdateArticleAsync(string id, Article updatedArticle)
    }
}