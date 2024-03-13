using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Application.Common.Interfaces
{
    public interface IDatabaseContext
    {
        Task<string> AddArticleAsync(Article article);
        Task<Article> GetArticleAsync(string id);
        Task<bool> UpdateArticleAsync(string id, Article updatedArticle);
        Task<DateTime> GetArticleLastEditAsync(string id);
        Task<Article[]> SearchArticlesAsync(string query);
        Task<string[]> GetArticleIdsAsync();

	}
}