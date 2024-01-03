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

        Article IArticleBuilder.Build()
        {
            throw new NotImplementedException();
        }

        IArticleBuilder IArticleBuilder.WithContent(string content)
        {
            article.Content = content;
            return this;
        }

        IArticleBuilder IArticleBuilder.WithDisciplines(Discipline[] disciplines)
        {
            article.Disciplines = disciplines;
            return this;
        }

        IArticleBuilder IArticleBuilder.WithSubjects(Subject[] subjects)
        {
            article.Subjects = subjects;
            return this;
        }

        IArticleBuilder IArticleBuilder.WithTitle(string title)
        {
            article.Title = title;
            return this;
        }

        IArticleBuilder IArticleBuilder.WithTopics(Topic[] topics)
        {
            article.Topics = topics;
            return this;
        }
    }
}
