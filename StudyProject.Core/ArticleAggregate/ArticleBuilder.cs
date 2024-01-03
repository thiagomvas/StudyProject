using StudyProject.Core.ArticleAggregate.Interfaces;
using StudyProject.Core.Models;

namespace StudyProject.Core.ArticleAggregate
{
    public class ArticleBuilder : IArticleBuilder
    {
        private readonly Article article = new();
        public Article Build()
        {
            return article;
        }

        IArticleBuilder IArticleBuilder.WithContent(string content)
        {
            article.Content = content;
            return this;
        }

        IArticleBuilder IArticleBuilder.WithSubjects(params Subject[] subjects)
        {
            article.Subjects = subjects;
            return this;
        }

        IArticleBuilder IArticleBuilder.WithTitle(string title)
        {
            article.Title = title;
            return this;
        }
    }
}
