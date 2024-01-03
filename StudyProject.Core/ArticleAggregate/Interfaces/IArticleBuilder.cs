using StudyProject.Core.Models;

namespace StudyProject.Core.ArticleAggregate.Interfaces
{
    internal interface IArticleBuilder
    {
        IArticleBuilder WithTitle(string title);
        IArticleBuilder WithContent(string content);
        IArticleBuilder WithSubjects(params Subject[] subjects);
        Article Build();
    }
}
