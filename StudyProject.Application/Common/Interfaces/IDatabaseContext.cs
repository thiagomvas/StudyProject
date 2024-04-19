using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;

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

        Task<string[]> GetStudyGuideIdsAsync();
        Task<StudyGuide> GetStudyGuideAsync(string name);
        Task<string> AddStudyGuideAsync(StudyGuide guide);

	}
}