using StudyProject.Application.Common.Builders;
using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Infrastructure.DTOs
{
	public class ArticleDTO
	{
		public string id { get; set; }
		public string title { get; set; }
		public string content { get; set; }

		public Article ToArticle()
		{
			return new ArticleBuilder().WithTitle(title).WithContent(content).WithId(id).Build();
		}
	}


}
