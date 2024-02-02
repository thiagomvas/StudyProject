using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Application.Common.Interfaces
{
    public interface IDatabaseContext
    {
        Task AddArticleAsync(Article article);
        Task<Article> GetArticleAsync(string id);
    }
}