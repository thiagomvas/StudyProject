using Microsoft.EntityFrameworkCore;
using StudyProject.Application.Common.Builders;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;

namespace StudyProject.Infrastructure
{
	public class ApplicationDbContext : IApplicationDbContext
	{
		private List<Article> articles = new List<Article>();
		public List<Article> Articles { get => articles; set => articles = value; }

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
			return Task.FromResult(Articles.Find(a => a.Id == id));
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
