using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Infrastructure.DTOs;
using System.Net.Http.Json;

namespace StudyProject.Infrastructure
{
	public class FirebaseContext : IDatabaseContext
	{
		private readonly FirebaseClient firebaseClient;

		public FirebaseContext(FirebaseClient firebaseClient)
		{
			this.firebaseClient = firebaseClient;
		}


        public async Task<Article> GetArticleAsync(string id)
        {
            try
            {
                return await firebaseClient.Child($"articles/{id}").OnceSingleAsync<Article>();
            }
            catch
            {
                Console.WriteLine("Couldn't find article with specified ID");
            }

            return Article.NotFound;

        }

        public async Task<string> AddArticleAsync(Article article)
        {
            article.LastEdit = DateTime.Now;
            try
            {
                string id = CreateId(article.Title);
                await firebaseClient.Child("articles").Child(id).PutAsync(article);
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding article: {ex.Message}");
            }
            return string.Empty;
        }

        public async Task<bool> UpdateArticleAsync(string id, Article updatedArticle)
        {
            updatedArticle.LastEdit = DateTime.Now;
            try
            {
                await firebaseClient.Child($"articles/{id}").PutAsync(JsonConvert.SerializeObject(updatedArticle));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating article: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteArticleAsync(string id)
        {
            try
            {
                await firebaseClient.Child($"articles/{id}").DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting article: {ex.Message}");
                return false;
            }
        }

		public async Task<DateTime> GetArticleLastEditAsync(string id)
		{
			try
			{
				return await firebaseClient.Child($"articles/{id}/LastEdit").OnceSingleAsync<DateTime>();
			}
			catch
			{
				Console.WriteLine("Couldn't find article with specified ID");
			}

			return DateTime.Now;

		}

        public string CreateId(string name) => name.Trim().Replace(" ", "-").ToLower();

		public async Task<Article[]> SearchArticlesAsync(string query)
		{
            var response = await firebaseClient.Child("articles")
                .OrderByKey()
                .StartAt(CreateId(query))
                .EndAt(query + "\uf8ff")
                .OnceAsync<Article>();

            var result = response.Select(e => e.Object).ToArray();


            return result;
		}
	}
}