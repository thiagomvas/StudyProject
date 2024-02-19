using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Application
{
	public class DatabaseAccess : IDatabaseContext
	{
		private readonly IDatabaseContext databaseContext;


        public string CreateId(string name) => name.Replace(" ", "-").ToLower();

        public DatabaseAccess(IDatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Article> GetArticleAsync(string id)
		{
			return await databaseContext.GetArticleAsync(id);
		}

		public async Task<string> AddArticleAsync(Article article)
		{
			var id = await databaseContext.AddArticleAsync(article);
			return id; 
		}

		public async Task<bool> UpdateArticleAsync(string id, Article updatedArticle)
		{
			return await databaseContext.UpdateArticleAsync(id, updatedArticle);
		}

		public async Task<DateTime> GetArticleLastEditAsync(string id)
		{
			return await databaseContext.GetArticleLastEditAsync(id);
		}

		public async Task<Article[]> SearchArticlesAsync(string query)
		{
			return await databaseContext.SearchArticlesAsync(query);
		}
	}
}
