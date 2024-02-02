using StudyProject.Core.ArticleAggregate;
using StudyProject.Infrastructure.DTOs;
using System.Net.Http.Json;

namespace StudyProject.Infrastructure
{
	public class FirebaseContext
	{
		private readonly HttpClient httpClient;

		public FirebaseContext(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<Article> GetArticleAsync(string id)
		{
			var response = await httpClient.GetAsync($"https://wikiforum-6f73d-default-rtdb.firebaseio.com/articles/{id}.json");
			if (response.IsSuccessStatusCode)
			{
				var dto = await response.Content.ReadFromJsonAsync<ArticleDTO>();
				return dto.ToArticle() ?? Article.NotFound;
			}
			else
			{
				return Article.NotFound;
			}
		}
	}
}
