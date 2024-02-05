using Newtonsoft.Json;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Infrastructure.DTOs;
using System.Net.Http.Json;

namespace StudyProject.Infrastructure
{
	public class FirebaseContext : IDatabaseContext
	{
		private readonly HttpClient httpClient;

		public FirebaseContext(HttpClient httpClient)
		{
			this.httpClient = httpClient;
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
            try
            {
                var result = await firebaseClient.Child("articles").PostAsync(JsonConvert.SerializeObject(article));
                return result.Key;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding article: {ex.Message}");
            }
            return string.Empty;
        }

        public async Task<bool> UpdateArticleAsync(string id, Article updatedArticle)
        {
            try
            {
                await firebaseClient.Child($"articles/{id}").PutAsync(updatedArticle);
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
    }
}