using StudyProject.Core.Models;

namespace StudyProject.Core.Interfaces
{
    public interface IArticleBuilder
    {
        IArticleBuilder WithTitle(string title);
        IArticleBuilder WithContent(string content);
        IArticleBuilder WithSubjects(params Subject[] subjects);
        IArticleBuilder Build();
    }
}
