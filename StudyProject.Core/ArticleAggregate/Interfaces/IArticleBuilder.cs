using StudyProject.Core.Models;

namespace StudyProject.Core.ArticleAggregate.Interfaces
{
    /// <summary>
    /// Represents an interface for building articles.
    /// </summary>
    public interface IArticleBuilder
    {
        /// <summary>
        /// Sets the title of the article.
        /// </summary>
        /// <param name="title">The title of the article.</param>
        /// <returns>The article builder instance after the operation has been done.</returns>
        public IArticleBuilder WithTitle(string title);

        /// <summary>
        /// Sets the content of the article.
        /// </summary>
        /// <param name="content">The content of the article.</param>
        /// <returns>The article builder instance after the operation has been done.</returns>
        public IArticleBuilder WithContent(string content);

        /// <summary>
        /// Sets the subjects of the article.
        /// </summary>
        /// <param name="subjects">The subjects of the article.</param>
        /// <returns>The article builder instance after the operation has been done.</returns>
        public IArticleBuilder WithSubjects(Subject[] subjects);

        /// <summary>
        /// Sets the disciplines of the article.
        /// </summary>
        /// <param name="disciplines">The disciplines of the article.</param>
        /// <returns>The article builder instance after the operation has been done.</returns>
        public IArticleBuilder WithDisciplines(Discipline[] disciplines);

        /// <summary>
        /// Sets the topics of the article.
        /// </summary>
        /// <param name="topics">The topics of the article.</param>
        /// <returns>The article builder instance after the operation has been done.</returns>
        public IArticleBuilder WithTopics(Topic[] topics);

        /// <summary>
        /// Builds the article.
        /// </summary>
        /// <returns>The built article.</returns>
        public Article Build();
    }
}
