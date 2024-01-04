using StudyProject.Application.Common.Builders;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;
using StudyProject.Infrastructure.DTOs;
using System.Net.Http.Json;

namespace StudyProject.Infrastructure
{
	public class ApplicationDbContext : IApplicationDbContext
	{

		private List<Article> articles = new List<Article>();
		public List<Article> Articles { get => articles; set => articles = value; }


		public async Task LoadData(string address)
		{
			using var client = new HttpClient();
            var _articles = await client.GetFromJsonAsync<ArticleDTO[]>(Path.Combine(address, "sample-data/articles.json"));
			Articles = _articles.Select(e => e.ToArticle()).ToList();
			Console.WriteLine($"Loaded {Articles.Count} articles");
		}

		public Task AddArticleAsync(Article article)
		{
			Console.WriteLine($"Add Article Async Called\nID: {article.Id}");
			Articles.Add(article);
            return Task.CompletedTask;
        }

		public Task DeleteArticleAsync(HexId id)
		{
			Console.WriteLine("Delete Article Async Called");
			Articles.Remove(Articles.Find(a => a.Id == id));
			return Task.CompletedTask;
		}

		public Task<Article> GetArticleByIdAsync(HexId id)
		{
            Console.WriteLine("Get Article By Id Async Called");
			var article = Articles.Find(a => a.Id == id) ?? Article.NotFound;

            return Task.FromResult(article);
		}

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
			Console.WriteLine("Save Changes Async Called");
			return Task.FromResult(1);
		}

		public Task UpdateArticleAsync(Article article)
		{
			Console.WriteLine("Update Article Async Called");
			Articles.Remove(Articles.Find(a => a.Id == article.Id));
			return Task.CompletedTask;

		}
	}


}
