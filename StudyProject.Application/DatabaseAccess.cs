using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Application
{
	public class DatabaseAccess
	{
		private readonly IDatabaseContext databaseContext;

		public DatabaseAccess(IDatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Article> GetArticleAsync(string id)
		{
			return await databaseContext.GetArticleAsync(id);
		}

		public async Task AddArticleAsync(Article article)
		{
			await databaseContext.AddArticleAsync(article);
		}
	}
}
