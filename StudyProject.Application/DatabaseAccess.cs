using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;

namespace StudyProject.Application
{
	public class DatabaseAccess : IDatabaseContext
	{
		private readonly IDatabaseContext databaseContext;


        public string CreateId(string name) => name.Replace(" ", "-").ToLower();
		public string GetNameFromId(string id) => (char.ToUpper(id[0]) + id.Substring(1)).Replace("-", " ");
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
			article.LastEdit = DateTime.Now;
			var id = await databaseContext.AddArticleAsync(article);
			return id; 
		}

		public async Task<bool> UpdateArticleAsync(string id, Article updatedArticle)
		{
			updatedArticle.LastEdit = DateTime.Now;
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

		public async Task<string[]> GetArticleIdsAsync()
		{
			return await databaseContext.GetArticleIdsAsync();
		}

        public async Task<string[]> GetStudyGuideIdsAsync()
        {
			return await databaseContext.GetStudyGuideIdsAsync();
        }

        public async Task<StudyGuide> GetStudyGuideAsync(string name)
        {
			return await databaseContext.GetStudyGuideAsync(name);
        }

        public async Task<string> AddStudyGuideAsync(StudyGuide guide)
        {
			return await databaseContext.AddStudyGuideAsync(guide);
        }

        public async Task<Exercise> GetExerciseAsync(string id)
        {
			return await databaseContext.GetExerciseAsync(id);
        }

		public async Task<string> AddExerciseAsync(Exercise exercise)
		{
			return await databaseContext.AddExerciseAsync(exercise);
		}
    }
}
