using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;

namespace StudyProject.Application.Articles.Commands.Create
{
    public class CreateArticleCommand : ICommand
    {
		public Article article;

		public CreateArticleCommand(Article article)
		{
			this.article = article;
		}
	}
}
