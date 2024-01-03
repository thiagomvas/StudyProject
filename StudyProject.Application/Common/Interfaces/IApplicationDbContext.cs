using Microsoft.EntityFrameworkCore;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;

namespace StudyProject.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Article> Articles { get; set; }

        Task<Article> GetArticleByIdAsync(HexId id);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task AddArticleAsync(Article article);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(HexId id);
    }
}
