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

		public async Task AddArticleAsync(Article article)
		{
			HttpContent content = new StringContent(JsonConvert.SerializeObject(article));
			await httpClient.PostAsync($"https://wikiforum-6f73d-default-rtdb.firebaseio.com/articles/.json", content);
		}
	}
}
